from function import *
import socket

host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))

class Node():
  def __init__(self, ticker):
    self.ticker = ticker
    self.current_price = None
    self.change_rate = None
    self.rsi = None
    self.macd = None
    self.market_depth = None
    self.rsi_position = None
    self.macd_opinion = None
    self.next = None

listed_ticker = []

class Info:
  def __init__(self):
    self.head = Node('head')
    self.head.next = self.head
    self.cur = self.head

  def insert(self, cur, ticker):
    new_node = Node(ticker)
    new_node.next = cur.next
    cur.next = new_node
    self.cur = new_node
    listed_ticker.append(ticker)

  def find(self, ticker):
    p = self.head
    while (p.ticker != ticker):
       p = p.next
    return p

  def find_prev(self, ticker):
    p = self.head
    while (p.next.ticker !=  ticker):
      p = p.next
    return p

  def delete(self, ticker):
    prev = self.find_prev(ticker)
    prev.next = prev.next.next

  def update(self, ticker, current_price, change_rate, rsi, macd, market_depth, rsi_position, macd_opinion):

    if ticker not in listed_ticker:
      self.insert(self.cur, ticker)

    else:
      if (self.cur.ticker != ticker):
        self.cur = self.find(ticker)

    self.cur.current_price = current_price
    self.cur.change_rate = change_rate
    self.cur.rsi = rsi
    self.cur.macd = macd
    self.cur.market_depth = market_depth
    self.cur.rsi_position = rsi_position
    self.cur.macd_opinion = macd_opinion

  def cur_show(self):
    print("TICKER:", self.cur.ticker)
    print("PRICE:", self.cur.current_price)
    print("CHANGE:", self.cur.change_rate)
    print("RSI:", self.cur.rsi)
    print("MACD:", self.cur.macd)
    print("DEPTH:", self.cur.market_depth)
    print("RSI_POSITION:", self.cur.rsi_position)
    print("MACD_SIGN:", self.cur.macd_opinion)
    print("\n")
    print("---next---")

  def list_return(self):
    return [self.cur.ticker, self.cur.current_price, self.cur.change_rate, self.cur.rsi, self.cur.macd, self.cur.market_depth, self.cur.rsi_position, self.cur.macd_opinion]

tickers = ['KRW-BTC', 'KRW-XRP', 'KRW-ETC', 'KRW-DOGE', 'KRW-ETH', 'KRW-ADA', 'KRW-EOS', 'KRW-STRAX', 'KRW-ARK', 'KRW-AQT', 'KRW-XLM', 'KRW-BCH', 'KRW-LTC', 'KRW-BTT', 'KRW-SBD', 'KRW-QTUM', 'KRW-VET', 'KRW-NEO', 'KRW-MANA', 'KRW-DOT','KRW-UPP','KRW-HUNT','KRW-TON','KRW-MED','KRW-DOT','KRW-MVL','KRW-CVC','KRW-SSX','KRW-RFR','KRW-MLK']

for ticker in tickers[:]:
    if ticker.startswith('BTC-'):
        tickers.remove(ticker)
    if ticker.startswith('USDT-'):
        tickers.remove(ticker)

info = Info()
Count = 0
while True:
  if (Count == 20):
    Count = 0
  if (Count == 0):
    trends_kr = get_trends_kr()
    trends_us = get_trends_us()
    trends = [['trends'], trends_kr, [0], trends_us]
    trends = sum(trends, [])
    posString = ','.join(map(str, trends))
    print(posString)
    sock.sendall(posString.encode("UTF-8"))
  for ticker in tickers:
    candles = get_candles(ticker)
    min_df = get_df(candles['min'])
    day_df = get_df(candles['day'])
    macd, macd_opinion = MACD_opinion(day_df)
    rsi, rsi_position = rsiindex(min_df)
    current_price = get_current_price(candles['tic'])
    change_rate = get_change_rate(candles['day'])
    market_depth = get_market_depth(candles['ord'])
    info.update(ticker, current_price, change_rate, rsi, macd, market_depth, rsi_position, macd_opinion)
    posString= ','.join(map(str, info.list_return()))
    print(posString)
    sock.sendall(posString.encode("UTF-8"))
    time.sleep(0.1)
  Count+=1
