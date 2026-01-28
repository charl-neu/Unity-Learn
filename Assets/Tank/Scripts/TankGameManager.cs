using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool debug = false;

    static TankGameManager instance;
    public static TankGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<TankGameManager>();
            }
            return instance;
        }
    }

    public int Score { get; set; } = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = (debug) ? 1f : 0f;
        titlePanel.SetActive(!debug);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score;
    }

    public void OnGameStart()
    {
        print("starting game");
        titlePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnGameWin()
    {
        StartCoroutine(ResetGameCR(2.0f));
    }

    public void OnGameOver()
    {
        print("game over!");
        StartCoroutine(ResetGameCR(2.0f));
    }

    IEnumerator ResetGameCR(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
