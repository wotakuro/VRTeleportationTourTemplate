using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector)) ]
public class TimelineControl : MonoBehaviour {
    private PlayableDirector playableDirector;


    private void Awake()
    {
        playableDirector = this.GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            playableDirector.Stop();
            playableDirector.Play();
        }
    }
}
