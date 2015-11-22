using UnityEngine;
using System.Collections;

public class Player : Creature {

    void Awake ()
    {
        //TODO check if necessary
    }

	void Start ()
    {
        HasInvincibility = true;
        InvincibleTime = 3;
	}

    void OnEnable()
    {
        Health = 5;
        this.transform.position = new Vector3(0, 0, 0);
    }

	void Update ()
    {
	    
	}

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
    }

    public override void Die()
    {
        Debug.Log("END");
        GameManager.instance.PlayerKilled();
        Application.LoadLevel(Application.loadedLevel);
    }

    public override void StartInvincibility()
    {
        base.StartInvincibility();
        Debug.Log("INVINCIBLE!");
        Debug.Log("Health left: " + Health);
    }

    public override void StopInvincibility()
    {
        base.StopInvincibility();
        Debug.Log("UH OH!");
    }
}
