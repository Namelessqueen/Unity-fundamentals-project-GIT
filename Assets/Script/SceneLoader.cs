using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool OnAwake = false;
    public string NextScene;
    public float transistionTime = 1;
    public Animator transition;

    // Update is called once per frame
    void Awake()
    {
        if (OnAwake)
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
