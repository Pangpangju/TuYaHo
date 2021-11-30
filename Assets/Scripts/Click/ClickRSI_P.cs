using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRSI_P : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RSI_PChange()
    {
        BitManager.Instance.RSI_P();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
