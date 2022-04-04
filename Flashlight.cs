using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject go;

    public void LightToggle(){
        if (go.activeInHierarchy)
        {
            go.SetActive(false);
        }
        else
        {
            go.SetActive(true);
        }
    }
}
