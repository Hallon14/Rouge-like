using UnityEngine;

public class RougeAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController playercontroller;
    [SerializeField] private Animator animator;

    void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        //ANIMATIONS
        if (playercontroller.inputVector == new Vector2(0, 0))
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }
    }
}
