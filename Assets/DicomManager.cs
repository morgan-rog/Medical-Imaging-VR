using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityVolumeRendering;
using UnityEngine.UI;
using TMPro;

public class DicomManager : MonoBehaviour
{
    public GameObject brainDicom;
    public GameObject patientDicom;

    public GameObject brainHandle;
    public GameObject patientHandle;

    public GameObject activeDicom;
    public GameObject activeDicomHandle;
    public GameObject[] dicomObjects;
    public GameObject[] dicomHandles;

    private VolumeRenderedObject volObjectComponent;

    private UnityVolumeRendering.RenderMode maxIntensity = UnityVolumeRendering.RenderMode.MaximumIntensityProjectipon;
    private UnityVolumeRendering.RenderMode directVol = UnityVolumeRendering.RenderMode.DirectVolumeRendering;
    private UnityVolumeRendering.RenderMode isoSurface = UnityVolumeRendering.RenderMode.IsosurfaceRendering;

    public GameObject lowValueTextObject;
    public GameObject highValueTextObject;

    TextMeshProUGUI lowValueText;
    TextMeshProUGUI highValueText;

    public GameObject renderModeDropdownObject;
    TMP_Dropdown renderDropDown;

    public float changeValueAmount = .1f;
    private float maxRange = 1.0f;
    private float minRange = 0.0f;
    private Vector2 valueRange;

    

    // Start is called before the first frame update
    void Start()
    {
        /*brainDicom = GameObject.Find("skull_dicom");
        patientDicom = GameObject.Find("patient_dicom");

        brainHandle = GameObject.Find("skull_handle");
        patientHandle = GameObject.Find("patient_handle");*/
        lowValueText = lowValueTextObject.GetComponent<TextMeshProUGUI>();
        highValueText = highValueTextObject.GetComponent<TextMeshProUGUI>();

        renderDropDown = renderModeDropdownObject.GetComponent<TMP_Dropdown>();

        ActivateBrainDicom();

    }

    /*void Update()
    {
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }*/

    private void UpdateText(float lowVal, float highVal)
    {
        lowValueText.text = lowVal.ToString();
        highValueText.text = highVal.ToString();
    }

    /*private void SetActiveDicom(GameObject dicom, GameObject handle)
    {
        activeDicom = GameObject.Find(dicom.name);
        activeDicomHandle = GameObject.Find(handle.name);
        activeDicom.SetActive(true);
        activeDicomHandle.SetActive(true);

        volObjectComponent = activeDicom.GetComponent<VolumeRenderedObject>();

        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }*/

    public void ActivateBrainDicom()
    {
        patientDicom.SetActive(false);
        patientHandle.SetActive(false);
        //SetActiveDicom(brainDicom, brainHandle);
        brainDicom.SetActive(true);
        brainHandle.SetActive(true);

        volObjectComponent = brainDicom.GetComponent<VolumeRenderedObject>();

        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);

        SetRenderMode(0);
        renderDropDown.SetValueWithoutNotify(0);
    }

    public void ActivatePatientDicom()
    {
        brainDicom.SetActive(false);
        brainHandle.SetActive(false);
        //SetActiveDicom(patientDicom, patientHandle);
        patientDicom.SetActive(true);
        patientHandle.SetActive(true);

        volObjectComponent = patientDicom.GetComponent<VolumeRenderedObject>();
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);

        SetRenderMode(0);
        renderDropDown.SetValueWithoutNotify(0);
    }

    public void SetRenderMode(int option)
    {
        //VolumeRenderedObject volObjectComponent = activeDicom.GetComponent<VolumeRenderedObject>();

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

    public void IncreaseLowVal()
    {
        //VolumeRenderedObject volObjectComponent = activeDicom.GetComponent<VolumeRenderedObject>();
        if (valueRange.x > valueRange.y)
        {
            volObjectComponent.SetVisibilityWindow(minRange, valueRange.y);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x + changeValueAmount, valueRange.y);
        }
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }

    public void DecreaseLowVal()
    {
        //VolumeRenderedObject volObjectComponent = activeDicom.GetComponent<VolumeRenderedObject>();
        if (valueRange.x < minRange)
        {
            volObjectComponent.SetVisibilityWindow(minRange, valueRange.y);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x - changeValueAmount, valueRange.y);
        }
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }

    public void IncreaseHighVal()
    {
        //VolumeRenderedObject volObjectComponent = activeDicom.GetComponent<VolumeRenderedObject>();
        if (valueRange.y > maxRange)
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, maxRange);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, valueRange.y + changeValueAmount);
        }
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }
    
    public void DecreaseHighVal()
    {
        //VolumeRenderedObject volObjectComponent = activeDicom.GetComponent<VolumeRenderedObject>();
        if (valueRange.y < valueRange.x)
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, maxRange);
        }
        else
        {
            volObjectComponent.SetVisibilityWindow(valueRange.x, valueRange.y - changeValueAmount);
        }
        valueRange = volObjectComponent.GetVisibilityWindow();
        UpdateText(valueRange.x, valueRange.y);
    }

}
