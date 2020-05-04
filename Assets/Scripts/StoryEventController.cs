using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum StoryKey {
    START_GAME
}

[Serializable]
public struct StoryEvent
{
    public StoryKey key;
    public string text;
    public float seconds;
}

public class StoryEventController : MonoBehaviour
{
    public const float DEFAULT_TEXT_TIME = 3;
    public Text eventText;
    
    public Dictionary<StoryKey, StoryEvent> storyEventsDict;

    public StoryEvent[] storyEvents;

    // Start is called before the first frame update
    void Start()
    {
        storyEventsDict = storyEvents.ToDictionary(item => item.key, item => item);
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal IEnumerator SetEventText(StoryKey key)
    {
        eventText.text = storyEventsDict[key].text;
        yield return new WaitForSeconds(storyEventsDict[key].seconds);
        eventText.text = "";
    }

    //IEnumerable SetEventTextStr(string text = "", float seconds = DEFAULT_TEXT_TIME)
    //{
    //    eventText.text = text;
    //    yield return new WaitForSeconds(seconds);
    //    eventText.text = "";
    //}
}
