using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlatController : MonoBehaviour
{
    
    public static GamePlatController instance;

    public BoxSpawner boxSpawner;
    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;

    public AudioClip[] audioclips;
    public AudioSource audioSource;

    public Text score_text;

    public GameObject GameOverImage;
    int moveCount = 0;
    int score_main = 0;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
        boxSpawner.spawnbox();

    }

    
    void Update()
    {
        DetectInput();

    }

    public void score_inc()
    {
        score_main++;
        score_text.text = "Box Dropped : " + score_main.ToString();

    }
    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 0.5f);
    }
    void NewBox()
    {
        boxSpawner.spawnbox();
        cameraScript.CameraSizeInc();
    }

    public void MoveCamera()
    {
        moveCount++;
        if(moveCount == 2)
        {
            moveCount = 0;
            Camera.main.orthographicSize += 1f;
            cameraScript.targetPos.y += 2f;
            
        }
    }

    public void RestartGame()
    {
        
        if (score_main > UIManager.highscore)
        {
            UIManager.highscore = score_main;
            PlayerPrefs.SetInt("highscore", UIManager.highscore);
        }
       
        

        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void ShowGameOver()
    {
        GameOverImage.SetActive(true);
    }
}
