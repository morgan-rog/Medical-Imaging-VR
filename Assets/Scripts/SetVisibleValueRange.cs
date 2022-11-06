using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityVolumeRendering;

public class SetVisibleValueRange : MonoBehaviour
{
    public VolumeRenderedObject theVolObject;
    public float changeValueAmount = .1f;
    private float maxRange = 1.0f;
    private float minRange = 0.0f;
    private Vector2 valueRange;

    public void IncreaseLowerValue()
    {
        VolumeRenderedObject volObjectComponent = theVolObject.GetComponent<VolumeRenderedObject>();
        valueRange = volObjectComponent.GetVisibilityWindow();
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
        VolumeRenderedObject volObjectComponent = theVolObject.GetComponent<VolumeRenderedObject>();
        valueRange = volObjectComponent.GetVisibilityWindow();
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
        VolumeRenderedObject volObjectComponent = theVolObject.GetComponent<VolumeRenderedObject>();
        valueRange = volObjectComponent.GetVisibilityWindow();
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
        VolumeRenderedObject volObjectComponent = theVolObject.GetComponent<VolumeRenderedObject>();
        valueRange = volObjectComponent.GetVisibilityWindow();
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
