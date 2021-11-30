using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void curChange()
    {
        BitManager.Instance.Cur();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
