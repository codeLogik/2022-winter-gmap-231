using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
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

    private IEnumerator LoadNewLevel(string newLevel)
    {
        // Show some UI
        finishLevelUI.SetActive(true);

        // Wait waitTimer seconds
        yield return new WaitForSeconds(waitTimer);

        // Load new level
        SceneManager.LoadScene(newLevel);
    }
}
