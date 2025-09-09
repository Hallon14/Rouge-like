using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ClassType classType;
    private RougeScript rougeScript;

    void Awake()
    {
        rougeScript = GetComponent<RougeScript>();
    } 

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (classType)
            {
                //case ClassType.BRUISER:
                    //rougeScript.direction.y = rougeScript.jumpForce * Time.deltaTime;
                    //return;

                case ClassType.ROUGE:
                    rougeScript.direction = Vector3.up * rougeScript.jumpForce;
                    Debug.Log("Hopp");
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

    public void Dash()
    {
        Debug.Log("Dashed");
    }
}