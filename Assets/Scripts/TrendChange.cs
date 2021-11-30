using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrendChange : MonoBehaviour{
    public Text Text1, Text2, Text3, Text4, Text5, Text6;
    void Update(){
        Text1.GetComponent<Text>().text = BitControl.returnTrends()[0].ToString();
        Text2.GetComponent<Text>().text = BitControl.returnTrends()[1].ToString();
        Text3.GetComponent<Text>().text = BitControl.returnTrends()[2].ToString();
        Text4.GetComponent<Text>().text = BitControl.returnTrends()[3].ToString();
        Text5.GetComponent<Text>().text = BitControl.returnTrends()[4].ToString();
        Text6.GetComponent<Text>().text = BitControl.returnTrends()[5].ToString();
    }
}
