using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;

public class ParentPlayerClass : MonoBehaviour
{
    public ClassType classType;
    public float MaxHeath;
    public float MaxMana;
    public float MoveSpeed;
    public float jumpForce;


    // Physics
    public UnityEngine.Vector3 direction;
    public float Gravity = -9.8f;

    public virtual void BasicAttack()
    {
        Debug.Log("Auto-Attack!");
    }

    public virtual void UtilitSpell()
    {
        Debug.Log("Utiliy Spell");
    }

    public virtual void DamageSpell()
    {
        Debug.Log("Damageing Spell");
    }

    public void Update()
    {
        direction.y = Gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

}

public enum ClassType
{
    ROUGE,
    MAGE,
    PRIEST,
    BRUISER
}
