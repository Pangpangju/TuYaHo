using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMACD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MACDChange()
    {
        BitManager.Instance.MACD();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
