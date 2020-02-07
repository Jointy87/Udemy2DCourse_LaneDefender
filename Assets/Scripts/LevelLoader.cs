using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //Parameters
    [SerializeField] int loadTime;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 0)
        {
            StartCoroutine(LoadTimer());
        }
    }

    IEnumerator LoadTimer()
    {
        yield return new WaitForSeconds(loadTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }
}
