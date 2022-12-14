using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[DisallowMultipleComponent]
[RequireComponent(typeof(XRGrabInteractable))]
public class XROffsetGrabbable : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    Transform attachPoint;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable.attachTransform == null)
        {
            GameObject newGO = new GameObject("Attach Transform of " + name);
            Transform newTransform = newGO.transform;
            newTransform.parent = transform;

            grabInteractable.attachTransform = newTransform;
            attachPoint = newTransform;
        }
        else
        {
            attachPoint = grabInteractable.attachTransform;
        }
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(XRSelectEnter);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(XRSelectEnter);
    }

    public void XRSelectEnter(SelectEnterEventArgs selectEnterEventArgs)
    {
        attachPoint.position = selectEnterEventArgs.interactorObject.transform.position;
        attachPoint.rotation = selectEnterEventArgs.interactorObject.transform.rotation;
    }
}
