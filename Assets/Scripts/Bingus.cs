using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bingus : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb2d;
    public Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb2d.linearVelocityX = moveSpeed;
    }

    public void Phoenix(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
        {
            return;
        }

        rb2d.linearVelocityY = jumpForce;
        animator.SetTrigger("john");
    }
}
