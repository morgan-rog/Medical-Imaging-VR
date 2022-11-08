using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTablePosition : MonoBehaviour
{
    public GameObject objectCopy;
    
    public float moveSpeed = 1.0f;
    private bool isSelected = false;
    private bool isAtTable = false;

    public GameObject tableManager;
    public Transform tableTarget;
    public Transform bedTarget;

    void Awake()
    {
        objectCopy.SetActive(false);
        tableManager = GameObject.Find("TableManager");
        tableTarget = GameObject.Find("TableManager").transform;
        bedTarget = GameObject.Find("BedPosition").transform;
    }

    public void setIsSelectedToTrue()
    {
        Debug.Log("object name: " + gameObject.name );
        TableObjectManager tableObjectmanager = tableManager.GetComponent<TableObjectManager>();
        if(tableObjectmanager.getNameOfActiveObject() == "none" || tableObjectmanager.getNameOfActiveObject() == gameObject.name)
        {
            tableObjectmanager.setNameOfActiveObject(gameObject.name);
            if (isAtTable)
            {
                objectCopy.SetActive(false);
            }
            isSelected = true;
        }
        
    }

    public void setTableObjectToEmpty()
    {
        TableObjectManager tableObjectmanager = tableManager.GetComponent<TableObjectManager>();
        tableObjectmanager.setNameOfActiveObject("none");
    }

    // Update is called once per frame
    void Update()
    {

        if (isSelected && !isAtTable)
        {
            gameObject.SetActive(true);
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, tableTarget.position, step);
        }
        else if (isSelected && isAtTable)
        {
            gameObject.SetActive(true);
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, bedTarget.position, step);
        }
        // check if object is at table or bed
        if (Vector3.Distance(transform.position, tableTarget.position) < 0.001f)
        {
            isAtTable = true;
            isSelected = false;
            gameObject.SetActive(false);
            objectCopy.SetActive(true);
        }
        else if (Vector3.Distance(transform.position, bedTarget.position) < 0.001f)
        {
            isAtTable = false;
            isSelected = false;
            gameObject.SetActive(true);
            objectCopy.SetActive(false);
            setTableObjectToEmpty();
        }
    }
}
