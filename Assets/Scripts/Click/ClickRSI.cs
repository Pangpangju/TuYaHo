using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRSI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RSIChange()
    {
        BitManager.Instance.RSI();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
