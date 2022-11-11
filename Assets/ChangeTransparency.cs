using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTransparency : MonoBehaviour
{

    public GameObject theOrgan;

    private Material currentMat;


    // Start is called before the first frame update
    void Start()
    {
        theOrgan = gameObject;
        currentMat = theOrgan.GetComponent<Renderer>().material;
    }


    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }

    public void ChangeAlphaOnValueChange(Slider slider)
    {
        ChangeAlpha(currentMat, slider.value);
    }

}
