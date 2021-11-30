using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitManager : MonoBehaviour{
    int Order = 0;
    private static BitManager instance = null;
    public GameObject button;
    GameObject buttonM;
    public GameObject parent;
    bool nameB, curB, MACDB, RSIB, SignalB, DepthB, MACD_SB, RSI_PB;
    public bool startbit = false;
    int buttonCount = 0;
    private void Start(){
        nameB = false;
        curB = false;
        MACDB = false;
        RSIB = false;
        SignalB = false;
        DepthB = false;
        MACD_SB = false;
        RSI_PB = false;
    }
    void Awake(){
        if (null == instance){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    public static BitManager Instance{
        get{
            if (null == instance){
                return null;
            }
            return instance;
        }
    }
    private void Update(){
        if (startbit){
            if (buttonCount <= 29){
                ButtonMake();
                buttonCount++;
            }
        }
    }
    public int ReturnOrder(){
        return Order-1;
    }
    public void ButtonMake(){
        buttonM = (GameObject)Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);
        buttonM.transform.SetParent(parent.transform,false);
        buttonM.name = BitControl.returnName(Order++);
    }
    public void makeStart() {
        startbit = true;
    }
    public bool NameSort(){
        return nameB;
    }
    public bool CurSort(){
        return curB;
    }
    public bool MACDSort(){
        return MACDB;
    }
    public bool RSISort(){
        return RSIB;
    }
    public bool SignalSort(){
        return SignalB;
    }
    public bool DepthSort(){
        return DepthB;
    }
    public bool MACD_SSort(){
        return MACD_SB;
    }
    public bool RSI_PSort(){
        return RSI_PB;
    }
    public void Name(){
        nameB = true;
    }
    public void Cur(){
        curB = true;
    }
    public void Signal(){
        SignalB = true;
    }
    public void RSI(){
        RSIB = true;
    }
    public void Depth(){
        DepthB = true;
    }
    public void MACD(){
        MACDB = true;
    }
    public void MACD_S(){
        MACD_SB = true;
    }
    public void RSI_P(){
        RSI_PB = true;
    }
    public void NameF(){
        nameB = false;
    }
    public void CurF(){
        curB = false;
    }
    public void MACDF(){
        MACDB = false;
    }
    public void RSIF(){
        RSIB = false;
    }
    public void SignalF(){
        SignalB = false;
    }
    public void DepthF(){
        DepthB = false;
    }
    public void RSI_PF(){
        RSI_PB = false;
    }
    public void MACD_SF(){
        MACD_SB = false;
    }
}
