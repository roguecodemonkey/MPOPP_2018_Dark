using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArealightDynamic : MonoBehaviour {
    public Vector3 targetPos,originPos;
	// Use this for initialization
	void Start () {
        originPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.Lerp(originPos, targetPos, Time.deltaTime*0.001f);
	}
}
