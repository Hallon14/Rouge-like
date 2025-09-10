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
    public float dashForce;

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



}

public enum ClassType
{
    ROUGE,
    MAGE,
    PRIEST,
    BRUISER
}
