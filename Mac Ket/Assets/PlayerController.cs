using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float forceAir = 20f;
    bool facingRight = true;
    [SerializeField] int numberJump = 2;
    int nJump = 2;

    Rigidbody2D rigidbody2D;
    Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        UpdateAnimation();
    }
    void CheckInput()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
                Flip();
            Run(-1);
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
                Flip();
            Run(1);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if(nJump > 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                nJump--;
            }
            //Debug.Log("Up");
        }
        /*else
        {
            rigidbody2D.velocity = Vector2.zero;
        }*/
        /*else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            move.y = -1;
        }*/
    }
    void Run(int value)
    {
        if (nJump != 2)
        {
            Vector2 forceToAdd = new Vector2(value * forceAir, 0);
            if (Mathf.Abs(rigidbody2D.velocity.x) < forceAir)
                rigidbody2D.AddForce(forceToAdd);
        }
        rigidbody2D.velocity = new Vector2(speed*value, rigidbody2D.velocity.y);
    }
    void UpdateAnimation()
    {
        int state = 0;
        if(Mathf.Abs(rigidbody2D.velocity.x) > 0.1f){
            state = 1;
        }
        if(rigidbody2D.velocity.y > 0.1f)
        {
            state = 2;
        }
        if(rigidbody2D.velocity.y < -0.1f)
        {
            state = 3;
        }
        animator.SetInteger("State", state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            nJump = numberJump;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

}
