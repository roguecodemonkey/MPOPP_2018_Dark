using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectTransporter : MonoBehaviour
{
	[SerializeField]
	bool positionTransport;

	[SerializeField]
	bool rotationTransport;

	[SerializeField]
	Transform pointA;

	[SerializeField]
	Transform pointB;

	[SerializeField]
	AnimationCurve positionalCurve;

	[SerializeField]
	AnimationCurve rotationalCurve;

	[SerializeField]

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
