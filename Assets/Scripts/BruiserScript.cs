using UnityEngine;

public class BruiserScript : ParentPlayerClass
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
