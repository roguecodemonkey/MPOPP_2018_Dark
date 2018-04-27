using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_move : MonoBehaviour {
    [SerializeField]
    GameObject Background;
    [SerializeField]
    GameObject pos0;
    [SerializeField]
    GameObject pos1;

    private Vector3 Background_position;


	// Use this for initialization
	void Start () {
        Background_position = Background.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Background_position = pos0.transform.position;
            Background.transform.position = Background_position;
            
        }
		
	}
}
