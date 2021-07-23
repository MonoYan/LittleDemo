using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class StoryControl : MonoBehaviour
{
    public bool isTrigger;
    public GameObject ui_tip;
    public PlayableDirector playableDirector;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Trigger")
        {
            ui_tip.gameObject.SetActive(true);
            isTrigger = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
