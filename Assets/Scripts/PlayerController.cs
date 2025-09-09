using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ClassType classType;
    private PlayerInputActions playerInputActions;
    private RougeScript rougeScript;
    private BruiserScript bruiserScript;
    private MageScript mageScript;
    private PriestScript priestScript;
    private float gravity = -9.8f;
    private UnityEngine.Vector3 direction;
    public Vector2 inputVector;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;


        rougeScript = GetComponent<RougeScript>();
        bruiserScript = GetComponent<BruiserScript>();
        mageScript = GetComponent<MageScript>();
        priestScript = GetComponent<PriestScript>();
    }
    void Update()
    {
        direction.y = gravity * Time.deltaTime;
        rougeScript.body.AddForceY(direction.y * Time.deltaTime);
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
        switch (classType)
        {
            case ClassType.ROUGE:
                rougeScript.body.linearVelocityX= inputVector.x * rougeScript.MoveSpeed;
                return;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (classType)
            {
                case ClassType.BRUISER:
                    bruiserScript.body.AddForce(UnityEngine.Vector3.up * bruiserScript.jumpForce);
                    return;

                case ClassType.ROUGE:
                    //rougeScript.body.AddForce(UnityEngine.Vector3.up * rougeScript.jumpForce);
                    rougeScript.body.linearVelocityY = rougeScript.jumpForce;
                    return;

                case ClassType.MAGE:
                    mageScript.body.AddForce(UnityEngine.Vector3.up * mageScript.jumpForce);
                    return;

                case ClassType.PRIEST:
                    priestScript.body.AddForce(UnityEngine.Vector3.up * priestScript.jumpForce);
                    return;
            }
        }

    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (classType)
            {
                //case ClassType.BRUISER:
                //rougeScript.direction.y = rougeScript.jumpForce * Time.deltaTime;
                //return;

                case ClassType.ROUGE:
                    rougeScript.body.AddForce(UnityEngine.Vector3.right * rougeScript.dashForce);
                    return;

                    //case ClassType.MAGE:
                    //rougeScript.direction.y = jumpForce * Time.deltaTime;
                    //return;

                    //case ClassType.PRIEST:
                    //rougeScript.direction.y = jumpForce * Time.deltaTime;
                    //return;
            }
        }
    }
}