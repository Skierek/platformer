using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jumpForce = 10;
    private bool canJump = true;
    private float maxSpeed = 5;
    public float stoppingForce = 5;
    public float dashForce = 3;
    private bool canDash = true;
    public float maxJump = 2;
    private float currentJump = 0;
    private Animator _animator;
    private float _initScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _initScale = transform.localScale.x;
    }

    // Fixedupdate 40/sec
    void FixedUpdate()
    {
        _animator.SetFloat("SpeedY", rigidbody2D.linearVelocityY);
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(_initScale, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0) 
        {
            transform.localScale = new Vector3(-_initScale, transform.localScale.y, transform.localScale.z);
        }
        PlayerMovmentHandle();
        PlayerMovmentStopping();
    }

    private void PlayerMovmentHandle()
    {
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
            _animator.SetBool("IsMoving" , true);
        }
        else if (rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
        if(direction.x == 0)
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    private void PlayerMovmentStopping()
    {
        if (!canDash)
        {
            return;
        }
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
  
        }
    }

    void OnJump()
    {
        if (canJump)
        {
            if (currentJump < maxJump)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                currentJump++;
            }
            else
            {
                canJump = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        currentJump = 0;
    }
    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    void OnDash()
    {
        if (canDash)
        {
            if (direction.x != 0)
            {
                rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
            }
            else 
            {
                rigidbody2D.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            }
                canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }

    IEnumerator ResetDash(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }
}
