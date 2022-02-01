using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevel : MonoBehaviour
{
    public GameObject finishLevelUI;
    public string nextLevelName;
    public float waitTimer = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadNewLevel(nextLevelName));
        }
    }

    // IEnumerator signals that this function can be called multiple times until it no longer yields a new value.
    // This is how a coroutine works in that Unity will call this function over each frame until it no longer yields a new result.
    IEnumerator LoadNewLevel(string sceneName)
    {
        // Activate the level complete screen and then wait for our wait time before doing anything else.
        finishLevelUI.SetActive(true);
        yield return new WaitForSeconds(waitTimer);

        // Load the next level.
        SceneManager.LoadScene(sceneName);
    }
}
