using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTitleController : MonoBehaviour
{
    [Tooltip("Delay in seconds between 'inserting a coin' and the game doing whatever.")]
    public float insertCoinDelay;
    public Blink insertCoinText;
    public AudioSource insertCoinSound;
    public string nameOfSceneToLoad;

    private bool coinInserted = false;


    private void Update()
    {
        if (coinInserted) return;

        if (Input.anyKeyDown)
        {
            StartCoroutine(OnInsertCoin());
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown($"joystick 1 button {i}"))
            {
                StartCoroutine(OnInsertCoin());
                return;
            }
        }
    }

    IEnumerator OnInsertCoin()
    {
        coinInserted = true;
        insertCoinSound.Play();
        insertCoinText.blinkDuration = 0.1f;
        insertCoinText.blinkPeriod = 0.1f;
        yield return new WaitForSeconds(insertCoinDelay);

        SceneManager.LoadScene(nameOfSceneToLoad);
    }
}
