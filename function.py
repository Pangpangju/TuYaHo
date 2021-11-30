from pytrends.request import TrendReq
import time
import pandas as pd
import requests


def get_candles(symbol):
    candles = {}

    tic_url = "https://api.upbit.com/v1/ticker"
    tic_querystring = {"markets": symbol}
    tic_response = requests.get(tic_url, params=tic_querystring)
    candles['tic'] = tic_response.json()

    min_url = "https://api.upbit.com/v1/candles/minutes/10"
    min_querystring = {"market": symbol, "count": "500"}
    min_response = requests.get(min_url, params=min_querystring)
    candles['min'] = min_response.json()

    day_url = "https://api.upbit.com/v1/candles/days"
    day_querystring = {"market": symbol, "count": "100"}
    day_response = requests.get(day_url, params=day_querystring)
    candles['day'] = day_response.json()

    ord_url = "https://api.upbit.com/v1/orderbook"
    ord_querystring = {"markets": symbol}
    ord_response = requests.get(ord_url, params=ord_querystring)
    candles['ord'] = ord_response.json()

    return candles

def get_market_depth(candles):
    df = pd.DataFrame(candles)
    return float(df['total_ask_size']) - float(df['total_bid_size'])

def get_current_price(candles):
    df = pd.DataFrame(candles)
    return float(df['trade_price'])

def get_change_rate(candles):
    df = pd.DataFrame(candles)
    return float(df['change_rate'][0])*100


# min&day candles df화
def get_df(candles):
    df = pd.DataFrame(candles)
    df = df.reindex(index=df.index[::-1]).reset_index()

    df['close'] = df['trade_price']

    return df

# get trends
def get_trends_kr():
    pytrends = TrendReq(hl='KR', tz=540)
    keywords = ['비트코인']
    pytrends.build_payload(keywords, cat=0, timeframe='now 7-d', geo='KR', gprop='')
    getdatainfo = pytrends.interest_over_time()
    getdatainfo = getdatainfo.reset_index()
    length = len(getdatainfo)
    trends = [getdatainfo['비트코인'][length -1], getdatainfo['비트코인'][length -25], getdatainfo['비트코인'][length - 49]]
    return trends

def get_trends_us():
    pytrends = TrendReq(hl='US', tz=540)
    keywords = ['bitcoin']
    pytrends.build_payload(keywords, cat=0, timeframe='now 7-d', geo='US', gprop='')
    getdatainfo = pytrends.interest_over_time()
    getdatainfo = getdatainfo.reset_index()
    length = len(getdatainfo)
    trends = [getdatainfo['bitcoin'][length - 1], getdatainfo['bitcoin'][length - 25], getdatainfo['bitcoin'][length - 49]]
    return trends

# rsi
def rsiindex(df):
    def rsi(ohlc, period=14):
        ohlc['close'] = ohlc["close"]
        delta = ohlc["close"].diff()

        up, down = delta.copy(), delta.copy()
        up[up < 0] = 0
        down[down > 0] = 0

        _gain = up.ewm(com=(period - 1), min_periods=period).mean()
        _loss = down.abs().ewm(com=(period - 1), min_periods=period).mean()

        RS = _gain / _loss
        return pd.Series(100 - (100 / (1 + RS)), name="RSI")

    rsi = rsi(df, 14).iloc[-1]

    call = '대기'

    if rsi < 30:
        call = '매수'
    if rsi > 70:
        call = '매도'

    return rsi, call


# macd
def MACD_opinion(ohlc):
    ohlc = ohlc['close']
    exp1 = ohlc.ewm(span=12, adjust=False).mean()
    exp2 = ohlc.ewm(span=26, adjust=False).mean()
    macd = exp1 - exp2
    exp3 = macd.ewm(span=9, adjust=False).mean()

    test1 = exp3[len(ohlc) - 1] - macd[len(ohlc) - 1]
    test2 = exp3[len(ohlc) - 2] - macd[len(ohlc) - 2]

    call = '매매 불필요'

    if test1 < 0 and test2 > 0:
        call = '매도'

    if test1 > 0 and test2 < 0:
        call = '매수'

    return macd[len(ohlc) - 1], call
