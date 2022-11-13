using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityVolumeRendering;
using UnityEngine.UI;
using TMPro;

public class SetVisibleValueRange : MonoBehaviour
{
    public VolumeRenderedObject volObjectComponent;
    public GameObject lowValueTextObject;
    public GameObject highValueTextObject;

    TextMeshProUGUI lowValueText;
    TextMeshProUGUI highValueText;

    public float changeValueAmount = .1f;
    private float maxRange = 1.0f;
    private float minRange = 0.0f;
    private Vector2 valueRange;

    void Start()
    {
        volObjectComponent = gameObject.GetComponent<VolumeRenderedObject>();
        lowValueText = lowValueTextObject.GetComponent<TextMeshProUGUI>();
        highValueText = highValueTextObject.GetComponent<TextMeshProUGUI>();

        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }

    void Update()
    {
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }

    private void UpdateText(float lowVal, float highVal) 
    {
        lowValueText.text = lowVal.ToString();
        highValueText.text = highVal.ToString();
    }


    public void IncreaseLowerValue()
    {
        if (valueRange.x > valueRange.y)
        {
            volObjectComponent.SetVisibilityWindow(minRange, valueRange.y);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x + changeValueAmount, valueRange.y);
        }
        
    }
    public void DecreaseLowerValue()
    {
        if (valueRange.x < minRange)
        {
            volObjectComponent.SetVisibilityWindow(minRange, valueRange.y);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x - changeValueAmount, valueRange.y);
        }

    }
    public void IncreaseHigherValue()
    {
        if (valueRange.y > maxRange)
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, maxRange);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, valueRange.y + changeValueAmount);
        }

    }
    public void DecreaseHigherValue()
    {
        if (valueRange.y < valueRange.x)
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, maxRange);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, valueRange.y - changeValueAmount);
        }

    }
}
