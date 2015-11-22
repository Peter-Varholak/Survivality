using UnityEngine;
using System.Collections;

public class Monster : Creature {

    int damageOnTouch;

	void OnEnable ()
    {
        Health = 2;
        HasInvincibility = true;
        InvincibleTime = 0.2f;
        damageOnTouch = 1;
	}

	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            ICanBeDamaged obj = hit.collider.GetComponent<ICanBeDamaged>();
            obj.TakeDamage(damageOnTouch);
        }        
    }
}
