using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFileBeGone : MonoBehaviour
{
   //This is a script to attach to instantiated audio files, so they won't remain in the scene after use
    // Update is called once per frame
    void Update()
    {
        //the audio file is deleted after 2 seconds
        Destroy(this.gameObject, 2);
    }
}
