using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventCollider : MonoBehaviour
{

    public StoryKey storyEvent;
    public StoryEventController storyEventController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(storyEventController.SetEventText(storyEvent));
    }
}
