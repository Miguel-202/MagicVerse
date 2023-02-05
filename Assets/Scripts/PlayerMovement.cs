using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float currentSpeed;
    public bool canMove = true;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInput();
        if (!canMove)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = currentSpeed;
        }

    }
    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Roll");
            StartCoroutine(CameraShake.Instance.ShakeCamera(1f, 0.3f));
        }
        if (moveDirection.magnitude == 1)
        {
            if (moveDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }
    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
        Debug.Log(newSpeed);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
