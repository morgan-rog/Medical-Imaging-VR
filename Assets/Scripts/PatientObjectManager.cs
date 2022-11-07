using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientObjectManager : MonoBehaviour
{
    //private GameObject theOrgan;
   
    public void ToggleActivation(GameObject theOrgan){
        Debug.Log("toggle activation");
        if (theOrgan.activeSelf)
        {
            theOrgan.SetActive(false);
        }
        else
        {
            theOrgan.SetActive(true);
        }
         
    }
}
