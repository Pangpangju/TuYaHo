using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExplain : MonoBehaviour{
    public GameObject Explain;
    GameObject Discription;
    void Start(){
        
    }
    void OnMouseEnter()
    {
        Debug.Log("Test");
        Discription = (GameObject)Instantiate(Explain, new Vector3(0,0,0), Quaternion.identity);
    }

    void OnMouseExit()
    {
        Destroy(Discription);
    }
    void OnMouseOver()
    {
        
    }
}
