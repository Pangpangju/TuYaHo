using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMACD_S : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MACD_SChange()
    {
        BitManager.Instance.MACD_S();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
