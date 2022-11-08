using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTablePosition : MonoBehaviour
{
    public GameObject objectCopy;
    public Transform tableTarget;
    public Transform bedTarget;
    public float moveSpeed = 1.0f;
    private bool isSelected = false;
    private bool isAtTable = false;

    public void setIsSelectedToTrue()
    {
        isSelected = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (isSelected && !isAtTable)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, tableTarget.position, step);
        }
        else if (isSelected && isAtTable)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, bedTarget.position, step);
        }
        // check if object is at table or bed
        if (Vector3.Distance(transform.position, tableTarget.position) < 0.001f)
        {
            isAtTable = true;
            isSelected = false;
        }
        else if (Vector3.Distance(transform.position, bedTarget.position) < 0.001f)
        {
            isAtTable = false;
            isSelected = false;
        }
    }
}
