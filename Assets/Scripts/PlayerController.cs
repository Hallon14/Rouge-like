using System.Numerics;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ClassType classType;
    private RougeScript rougeScript;
    private BruiserScript bruiserScript;
    private MageScript mageScript;
    private PriestScript priestScript;

    void Awake()
    {
        rougeScript = GetComponent<RougeScript>();
        bruiserScript = GetComponent<BruiserScript>();
        mageScript = GetComponent<MageScript>();
        priestScript = GetComponent<PriestScript>();
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
                    rougeScript.body.AddForce(UnityEngine.Vector3.up * rougeScript.jumpForce);
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