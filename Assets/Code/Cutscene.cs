using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }
    
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(31f);
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

