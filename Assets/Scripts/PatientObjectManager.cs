using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientObjectManager : MonoBehaviour
{
    //private GameObject theOrgan;
    //public bool isInteractionActive = false;
   
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

    /*public void setIsInteractionActive(bool value)
    {
        isInteractionActive = value;
    }*/

    /*public void ToggleMovementToTable(GameObject theOrgan)
    {

        MoveToTablePosition organTablePosScript = theOrgan.GetComponent<MoveToTablePosition>();

        organTablePosScript.setIsSelectedToTrue();
    }*/

}
