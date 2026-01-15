using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        print("you win!");
        Time.timeScale = 0f;    
    }
}
