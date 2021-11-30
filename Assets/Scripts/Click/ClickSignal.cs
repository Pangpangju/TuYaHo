using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSignal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void signalChange()
    {
        BitManager.Instance.Signal();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
