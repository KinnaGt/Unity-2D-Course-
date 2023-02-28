using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
            Debug.Log("Enter");
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(1);
        int nextScene = SceneManager.GetActiveScene().buildIndex +1;
        if (nextScene == SceneManager.sceneCountInBuildSettings){
            nextScene = 0;
        }
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        SceneManager.LoadScene(nextScene);
    }
}
