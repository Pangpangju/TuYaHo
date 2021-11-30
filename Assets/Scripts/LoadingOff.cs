using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingOff : MonoBehaviour{
    public GameObject Loading;
    public static bool DT = false;
    void Start() {

    }
    void destroyLoading() {
        Destroy(Loading);
    }

    public static void destroyTrigger(){
        DT = true;
    }

    void Update(){
        if (DT) {
            destroyLoading();
            Destroy(this);
        }
    }
}
