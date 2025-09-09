using UnityEditor.Callbacks;
using UnityEngine;

public class RougeAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController playercontroller;
    [SerializeField] private Animator animator;

    private Vector3 direction;
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = body.linearVelocity.normalized;

        //ANIMATIONS
        if (playercontroller.inputVector == new Vector2(0, 0))
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }

        if (direction.y < 0)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
        else if (direction.y > 0)
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            
        }
    }
}
