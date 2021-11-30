using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDepth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DepthChange()
    {
        BitManager.Instance.Depth();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
