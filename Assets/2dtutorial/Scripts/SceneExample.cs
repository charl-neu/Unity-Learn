using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using CGL.DesignPatterns;
using System.Collections;

public class SceneExample : Singleton<SceneExample>
{
    [SerializeField] string sceneName01;
    [SerializeField] string sceneName02;
    [SerializeField] string sceneName03;

    void OnValidate()
    {
        if (string.IsNullOrEmpty(sceneName01))
        {
            Debug.Log("no scene name");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneName01);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneName02);
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneName03);
            StartCoroutine(LoadSceneCoroutine(sceneName03));
        }
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return null;
    }
}
