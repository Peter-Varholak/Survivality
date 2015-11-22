using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour, ICanBeDamaged {

    public int Health { get; set; }
    public bool HasInvincibility { get; set; }
    public bool InvincibilityActive { get; set; }
    public float InvincibleTime { get; set; }

    public virtual void TakeDamage(int damageAmount)
    {
        if (!InvincibilityActive)
        {
            Health -= damageAmount;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }

            if (HasInvincibility)
            {
                StartInvincibility();
            }      
        }          
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
        GameManager.instance.MonsterKilled();
    }

    public virtual void StartInvincibility()
    {
        if(!InvincibilityActive)
        {
            InvincibilityActive = true;
            Invoke("StopInvincibility", InvincibleTime);
        }
    }

    public virtual void StopInvincibility()
    {
        InvincibilityActive = false;
    }
}
