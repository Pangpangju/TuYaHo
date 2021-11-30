using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitControl : MonoBehaviour
{
    void Start(){
        TrendList.Add(new Trends(0,0,0,0,0,0));
    }
    public struct CoinInfo{
        public string Name;
        public float CurrentValue;
        public float RSI;
        public float MACD;
        public float Signal;
        public float Depth;
        public string RSI_Position;
        public string MACD_Sign;
        public CoinInfo(string a, float b, float c, float d, float e, float f, string g, string h) {
            this.Name = a;
            this.CurrentValue = b;
            this.RSI = c;
            this.MACD = d;
            this.Signal = e;
            this.Depth = f;
            this.RSI_Position = g;
            this.MACD_Sign = h;
        }
    }
    static List<CoinInfo> InfoList = new List<CoinInfo>();
    static List<Trends> TrendList = new List<Trends>();
    public struct Trends
    {
        public int KOR1;
        public int KOR2;
        public int KOR3;
        public int USA1;
        public int USA2;
        public int USA3;
        public Trends(int a, int b, int c, int d, int e, int f)
        {
            this.KOR1 =a;
            this.KOR2 = b;
            this.KOR3 = c;
            this.USA1 = d;
            this.USA2 = e;
            this.USA3 = f;
        }
    }


    public static void addInfo(string Name, float CurrentValue, float RSI, float MACD, float Signal, float Depth, string RSI_Position, string MACD_Sign){
        InfoList.Add(new CoinInfo(Name, CurrentValue, RSI, MACD, Signal, Depth, RSI_Position, MACD_Sign));
        Debug.Log(InfoList.Count);
        if (InfoList.Count == 30){
            BitManager.Instance.makeStart();
            LoadingOff.destroyTrigger();
        }
    }
    public static void addTrends(int KOR1, int KOR2, int KOR3, int USA1, int USA2, int USA3){
        Trends tmp = TrendList[0];
        tmp.KOR1 = KOR1;
        tmp.KOR2 = KOR2;
        tmp.KOR3 = KOR3;
        tmp.USA1 = USA1;
        tmp.USA2 = USA2;
        tmp.USA3 = USA3;
        TrendList[0] = tmp;
    }
    public static int[] returnTrends() {
        int[] TArray = new int[6];
        TArray[0] = TrendList[0].KOR1;
        TArray[1] = TrendList[0].KOR2;
        TArray[2] = TrendList[0].KOR3;
        TArray[3] = TrendList[0].USA1;
        TArray[4] = TrendList[0].USA3;
        TArray[5] = TrendList[0].USA2;
        return TArray;
    }
    public static int sortInfoName(CoinInfo a, CoinInfo b){
        return a.Name.CompareTo(b.Name);
    }
    public static int sortInfoCur(CoinInfo a, CoinInfo b){
        return a.CurrentValue.CompareTo(b.CurrentValue);
    }
    public static int sortInfoRSI(CoinInfo a, CoinInfo b){
        return a.RSI.CompareTo(b.RSI);
    }
    public static int sortInfoMACD(CoinInfo a, CoinInfo b){
        return a.MACD.CompareTo(b.MACD);
    }
    public static int sortInfoSignal(CoinInfo a, CoinInfo b){
        return a.Signal.CompareTo(b.Signal);
    }
    public static int sortInfoDepth(CoinInfo a, CoinInfo b){
        return a.Depth.CompareTo(b.Depth);
    }
    public static int sortInfoRSI_P(CoinInfo a, CoinInfo b){
        return a.RSI_Position.CompareTo(b.RSI_Position);
    }
    public static int sortInfoMACD_S(CoinInfo a, CoinInfo b){
        return a.MACD_Sign.CompareTo(b.MACD_Sign);
    }
    public static void sortName() {
        InfoList.Sort(sortInfoName);
    }
    public static void sortCur(){
        InfoList.Sort(sortInfoCur);
    }
    public static void sortRSI(){
        InfoList.Sort(sortInfoRSI);
    }
    public static void sortMACD(){
        InfoList.Sort(sortInfoMACD);
    }
    public static void sortSignal(){
        InfoList.Sort(sortInfoSignal);
    }
    public static void sortDepth(){
        InfoList.Sort(sortInfoDepth);
    }
    public static void sortRSI_P(){
        InfoList.Sort(sortInfoRSI_P);
    }
    public static void sortMACD_S(){
        InfoList.Sort(sortInfoMACD_S);
    }
    public static void changeNumber(string Name, float CurrentValue, float OldValue, float RSI, float MACD, float Signal, float Depth, string RSI_Position, string MACD_Sign){
        CoinInfo tmp = InfoList[sortInfoFunctionName(Name)];
        tmp.Name = Name;
        tmp.CurrentValue = CurrentValue;
        tmp.RSI = RSI;
        tmp.MACD = MACD;
        tmp.Signal = Signal;
        tmp.Depth = Depth;
        tmp.RSI_Position = RSI_Position;
        tmp.MACD_Sign = MACD_Sign;
        InfoList[sortInfoFunctionName(Name)] = tmp;
    }
    public static int sortInfoFunctionName(string Name)
    {
        for (int i = 0; i < InfoList.Count; i++)
        {
            if (InfoList[i].Name == Name) return i;
        }
        return -1;
    }

    public static string returnName(int index){
        return InfoList[index].Name;
    }
    public static float returnCur(int index){
        return InfoList[index].CurrentValue;
    }
    public static float returnRSI(int index){
        return InfoList[index].RSI;
    }
    public static float returnMACD(int index){
        return InfoList[index].MACD;
    }
    public static float returnSignal(int index){
        return InfoList[index].Signal;
    }
    public static float returnDepth(int index){
        return InfoList[index].Depth;
    }
    public static string returnRSI_P(int index){
        return InfoList[index].RSI_Position;
    }
    public static string returnMACD_S(int index){
        return InfoList[index].MACD_Sign;
    }
    public static bool checkfull(){
        if (InfoList.Count == 30) return true;
        return false;
    }
}
