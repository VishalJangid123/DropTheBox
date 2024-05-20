using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Rigidbody2D box_rb;
    private float moveSpeed = 2.0f;
    private float max_x = 2f;
    private float min_x = -2f;
    private bool canMove;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    private bool gameOver;

    void Awake()
    {
        box_rb = GetComponent<Rigidbody2D>();
        box_rb.gravityScale = 0;
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

    void Update()
    {
        MoveBox();    
    }

    public void DropBox()
    {
        canMove = false;
        box_rb.gravityScale = Random.Range(2, 4);
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
