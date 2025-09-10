using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class RougeScript : ParentPlayerClass
{
    void Awake()
    {
        MaxHeath = 100;
        MaxMana = 100;
        MoveSpeed = 10;
        jumpForce = 10;
        dashForce = 100f;
    }
}
