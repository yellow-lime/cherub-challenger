using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blinkPeriod;
    public float blinkDuration;
    private float timeToToggle;

    // Update is called once per frame
    void Update()
    {
        timeToToggle -= Time.deltaTime;
        if(timeToToggle < 0f){
            this.gameObject.SetActive(!this.gameObject.activeSelf);
            timeToToggle = (this.gameObject.activeSelf ? blinkPeriod : blinkDuration);
        }
    }
}
