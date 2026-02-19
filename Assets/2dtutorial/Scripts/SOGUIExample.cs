using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SOGUIExample : MonoBehaviour
{
    [SerializeField] IntData score;
    [SerializeField] TMP_Text text;
    
    // Update is called once per frame
    void Update()
    {
        text.text = score.value.ToString("0000");
    }
}
