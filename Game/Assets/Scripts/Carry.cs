﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carry : MonoBehaviour {
    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;


    [SerializeField]
    float MaxDistance;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    LayerMask usable_layer;

    [SerializeField]
    GameObject mention;


    Quaternion origRotation;

    private void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxDistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            if ((1 << hit.transform.gameObject.layer & usable_layer) != 0)
                mention.SetActive(true);
            else
                mention.SetActive(false);
        }
        else mention.SetActive(false);


        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }

    }

    void carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position,mainCamera.transform.position + mainCamera.transform.forward * distance,Time.deltaTime*smooth);
    }
    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
              
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p!= null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    p.transform.SetParent(transform);
                }


            }
        }
    }
    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
    }
    void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.transform.SetParent(null);
        carriedObject = null;
    }
}
