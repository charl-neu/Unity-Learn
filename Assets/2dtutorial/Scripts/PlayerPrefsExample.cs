using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPrefsExample : MonoBehaviour
{
    int highscore = 0;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        print($"Highscore: {highscore}");
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            OnSetHighScore(200);
        }
    }

    void OnSetHighScore(int score)
    {
        highscore = score;
        PlayerPrefs.SetInt("Highscore", highscore);
    }
}
