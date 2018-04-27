using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_move : MonoBehaviour {
    [SerializeField]
    GameObject Background;
    [SerializeField]
    GameObject Background1;
    [SerializeField]
    GameObject pos0;

    private Vector3 Background_position;
    private int Background_num= 0;

	// Use this for initialization
	void Start () {
        Background_position = Background.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

    

    }
}
