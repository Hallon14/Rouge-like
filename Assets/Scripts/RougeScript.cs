using Unity.VisualScripting;
using UnityEngine;

public class RougeScript : ParentPlayerClass
{
    void Awake()
    {
        MaxHeath = 100;
        MaxMana = 100;
        MoveSpeed = 10;
        jumpForce = 5f;
    }
}
