using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    [SerializeField]
    Slider Background_Volume;

    [SerializeField]
    Slider Player_Volume;

    [SerializeField]
    AudioSource BackGroundMusic;

    [SerializeField]
    AudioSource PlayerVolume;




    // Update is called once per frame
    void Update () {
        BackGroundMusic.volume = Background_Volume.value;
        PlayerVolume.volume = Player_Volume.value;

    }
}
