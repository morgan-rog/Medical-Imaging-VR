using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityVolumeRendering;

public class SetRenderModeType : MonoBehaviour
{
    public VolumeRenderedObject theVolObject;
    private UnityVolumeRendering.RenderMode maxIntensity = UnityVolumeRendering.RenderMode.MaximumIntensityProjectipon;
    private UnityVolumeRendering.RenderMode directVol = UnityVolumeRendering.RenderMode.DirectVolumeRendering;
    private UnityVolumeRendering.RenderMode isoSurface = UnityVolumeRendering.RenderMode.IsosurfaceRendering;

    private void Start()
    {
        theVolObject = gameObject.GetComponent<VolumeRenderedObject>();
    }

    public void setRenderModeType(int option)
    {
        VolumeRenderedObject volObjectComponent = theVolObject.GetComponent<VolumeRenderedObject>();

        if (option == 0)
        {
            volObjectComponent.SetRenderMode(directVol);
        }
        else if (option == 1)
        {
            volObjectComponent.SetRenderMode(maxIntensity);
        }
        else if (option == 2)
        {
            volObjectComponent.SetRenderMode(isoSurface);
        }
        
    }
}
