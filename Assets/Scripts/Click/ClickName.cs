using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickName : MonoBehaviour
{
    void Start()
    {
    }

    public void nameChange() {
        BitManager.Instance.Name();
    }

    void Update()
    {
        
    }
}
