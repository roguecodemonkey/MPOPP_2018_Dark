using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadButton : MonoBehaviour {


	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("2nd floor");
        }
	}
}
