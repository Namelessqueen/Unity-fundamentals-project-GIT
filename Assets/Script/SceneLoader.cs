using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool Go = true;
    public string NextScene;
    public float transistionTime = 1;
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) &&  Go)
        {
            LoadNextScene();
        }   
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(NextScene));
    }

    IEnumerator LoadLevel(string SceneName)
    {
        Time.timeScale = 1.0f;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transistionTime);
        SceneManager.LoadScene(SceneName);
    }
}
