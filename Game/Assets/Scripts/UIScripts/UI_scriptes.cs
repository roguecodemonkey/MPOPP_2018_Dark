using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_scriptes : MonoBehaviour
{
    [SerializeField]
    float MaxDistance;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    string usable_layer;

    [SerializeField]
    Text mention;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxDistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.name == usable_layer)
                mention.enabled = true;
            else
                mention.enabled = false;
        }
        else
            mention.enabled = false;
    }
}
