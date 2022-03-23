using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ActionByTouch : EventTrigger
{   

    private MoveByTouch anotherScript;
    void Awake ()
    {
        anotherScript = GetComponent<MoveByTouch>();

    }

    public void Shoot(){
        anotherScript.Shoot();
    } 

}