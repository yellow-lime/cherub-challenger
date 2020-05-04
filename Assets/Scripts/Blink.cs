using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    [Tooltip("Time it stays visible, in seconds.")]
    public float blinkPeriod;
    [Tooltip("Time it stays invisible, in seconds.")]
    public float blinkDuration;
    [Tooltip("Is currently in the process of blinking (be it visible or invisible).")]
    public bool isBlinking = true;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(onBlink());
    }

    IEnumerator onBlink()
    {
        while (isBlinking)
        {
            text.enabled = !text.enabled;
            if (text.enabled)
            {
                yield return new WaitForSeconds(blinkPeriod);
            } else yield return new WaitForSeconds(blinkDuration);
        }
    }
}
