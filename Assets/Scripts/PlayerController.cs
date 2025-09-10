using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ClassType classType;
    private PlayerInputActions playerInputActions;
    

    private float gravity = -9.8f;
    private UnityEngine.Vector3 direction;
    public Vector2 inputVector;
    private Rigidbody2D body;


    void Awake()
    {
        body = FindAnyObjectByType<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    void Update()
    {
        direction.y = gravity * Time.deltaTime;
        body.AddForceY(direction.y * Time.deltaTime);
    }

    void FixedUpdate()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();


        //Flipping Sprite - input less than 0 indicates movement to the left
        if (inputVector.x < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
        if (inputVector.x > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }

        //Movement
        body.linearVelocityX = inputVector.x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            body.linearVelocityY = 150f;


    }

    public void Dash(InputAction.CallbackContext context)
    {

    }
}