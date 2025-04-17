using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExample : MonoBehaviour
{

    public AudioClip shouting;
    public SoundManager soundManager;   

    // Start is called before the first frame update
    void Start()
    {
        soundManager.PlaySoundAltered(shouting, 0.5f);
    }
}


