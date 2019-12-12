using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int highscore;
    public Text highScore_text;
    public void MoveToMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }
    void Update()
    {
        highScore_text.text = highscore.ToString();
    }
}
