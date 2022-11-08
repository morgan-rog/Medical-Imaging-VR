using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObjectManager : MonoBehaviour
{
    public string nameOfActiveObject;

    void Awake()
    {
        setNameOfActiveObject("none");
    }

    public void setNameOfActiveObject(string name)
    {
        nameOfActiveObject = name;
    }

    public string getNameOfActiveObject()
    {
        return nameOfActiveObject;
    }
}
