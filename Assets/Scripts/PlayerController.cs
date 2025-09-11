using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ClassType classType;
    [SerializeField] private Unitdata classData;
    [SerializeField] private Rigidbody2D body;
    private PlayerInputActions playerInputActions;


    private Vector3 gravity = new Vector3(0f, -9.8f);
    private Vector3 direction = Vector3.zero;
    public Vector2 inputVector;
    


    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    void Update()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }

    public void FixedUpdate()
    {
        direction = gravity * Time.deltaTime;
        body.MovePosition(transform.position += direction * Time.deltaTime * 50);
        flipSprite();
        
    }
    
    public void flipSprite()
    {
        //Flipping Sprite - input less than 0 indicates movement to the left
        if (inputVector.x < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3); // ATM set to 3 as that makes Rouge in good size, change this later pls
        }
        if (inputVector.x > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
    }


    public virtual void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            body.linearVelocityY = classData.jumpForce;  
    }

    public virtual void Dash(InputAction.CallbackContext context)
    {

    }
    
}