using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour{
    public Text Text1, Text2, Text3, Text4, Text5, Text6, Text7, Text8;
    float CurrentValue, RSI, MACD, Signal, Depth;
    string Name, RSI_Position, MACD_Signal;
    public int order;
    Image buttonColor;

    void Start(){
        buttonColor = gameObject.GetComponent<Image>();
        Name = BitControl.returnName(BitManager.Instance.ReturnOrder());
        CurrentValue = BitControl.returnCur(BitManager.Instance.ReturnOrder());
        RSI = BitControl.returnRSI(BitManager.Instance.ReturnOrder());
        MACD = BitControl.returnMACD(BitManager.Instance.ReturnOrder());
        Signal = BitControl.returnSignal(BitManager.Instance.ReturnOrder());
        Depth = BitControl.returnDepth(BitManager.Instance.ReturnOrder());
        RSI_Position = BitControl.returnRSI_P(BitManager.Instance.ReturnOrder());
        MACD_Signal = BitControl.returnMACD_S(BitManager.Instance.ReturnOrder());
        order = BitManager.Instance.ReturnOrder();
        

    }
    void Update(){
        if (RSI >= 0) buttonColor.color = new Color(218 / 255f, 35 / 255f, 35 / 255f, 134 / 255f);
        if (RSI<0) buttonColor.color = new Color(6 / 255f, 85 / 255f, 200 / 255f, 134 / 255f);
        Name = BitControl.returnName(order);
        CurrentValue = BitControl.returnCur(order);
        RSI = BitControl.returnRSI(order);
        MACD = BitControl.returnMACD(order);
        Signal = BitControl.returnSignal(order);
        Depth = BitControl.returnDepth(order);
        RSI_Position = BitControl.returnRSI_P(order);
        MACD_Signal = BitControl.returnMACD_S(order);
        if (BitManager.Instance.NameSort() == true) {
            BitManager.Instance.NameF();
            BitControl.sortName();
        }
        if (BitManager.Instance.CurSort() == true){
            BitManager.Instance.CurF();
            BitControl.sortCur();
        }
        if (BitManager.Instance.RSISort() == true){
            BitManager.Instance.RSIF();
            BitControl.sortRSI();
        }
        if (BitManager.Instance.MACDSort() == true){
            BitManager.Instance.MACDF();
            BitControl.sortMACD();
        }
        if (BitManager.Instance.SignalSort() == true){
            BitManager.Instance.SignalF();
            BitControl.sortSignal();
        }
        if (BitManager.Instance.DepthSort() == true){
            BitManager.Instance.DepthF();
            BitControl.sortDepth();
        }
        if (BitManager.Instance.RSI_PSort() == true){
            BitManager.Instance.RSI_PF();
            BitControl.sortRSI_P();
        }
        if (BitManager.Instance.MACD_SSort() == true){
            BitManager.Instance.MACD_SF();
            BitControl.sortMACD_S();
        }
        Text1.GetComponent<Text>().text = Name;
        if (CurrentValue.ToString("F0").Length < 2) Text2.GetComponent<Text>().text = CurrentValue.ToString("F2");
        else Text2.GetComponent<Text>().text = CurrentValue.ToString("F0");
        Text3.GetComponent<Text>().text = RSI.ToString("F2") + "%";
        Text4.GetComponent<Text>().text = MACD.ToString("F0");
        Text5.GetComponent<Text>().text = Signal.ToString("F0");
        Text6.GetComponent<Text>().text = Depth.ToString("F2");
        Text7.GetComponent<Text>().text = RSI_Position;
        Text8.GetComponent<Text>().text = MACD_Signal;
    }
}
