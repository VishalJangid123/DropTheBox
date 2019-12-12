using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    Rigidbody2D box_r;
    float moveSpeed = 2.0f;
    float max_x = 2f, min_x = -2f;
    private bool canMove, ignoreCollision, ignoreTrigger, gameOver;
    // Start is called before the first frame update
    void Awake()
    {
        box_r = GetComponent<Rigidbody2D>();
        box_r.gravityScale = 0;
    }
    void Start()
    {
        canMove = true;
        if (Random.Range(0, 2)>0)
        {
            moveSpeed *= -1f;
        }
        GamePlatController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();    
    }

    public void DropBox()
    {
        canMove = false;
        box_r.gravityScale = Random.Range(2, 4);
    }

    public void Landed()
    {
        if (gameOver)
            return;

        ignoreCollision = true;
        ignoreTrigger = true;

        GamePlatController.instance.SpawnNewBox();
        GamePlatController.instance.MoveCamera();
    }

    void Restart()
    {
        GamePlatController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
       
        if (ignoreCollision)
            return;

        if(target.gameObject.tag == "Platforom" || target.gameObject.tag == "Box")
        {
            GamePlatController.instance.audioSource.clip = GamePlatController.instance.audioclips[Random.Range(0, GamePlatController.instance.audioclips.Length)];
            GamePlatController.instance.audioSource.Play();
            Invoke("Landed", 2f);
            GamePlatController.instance.score_inc();
            ignoreCollision = true;
        }
    
    }

    void OnTriggerEnter2D(Collider2D target)
    {
      
        //if (ignoreTrigger)
          //  return;

        if (target.gameObject.tag == "GameOver")
        {
            GamePlatController.instance.audioSource.clip = GamePlatController.instance.audioclips[Random.Range(0, GamePlatController.instance.audioclips.Length)];
            GamePlatController.instance.audioSource.Play();
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            GamePlatController.instance.ShowGameOver();
            Invoke("Restart", 3f);
        }
    }
    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            if (temp.x > max_x)
            {
                moveSpeed *= -1f;
            }
            else if (temp.x < min_x)
            {
                moveSpeed *= -1f;
            }
            transform.position = temp;
        }
    }
}
