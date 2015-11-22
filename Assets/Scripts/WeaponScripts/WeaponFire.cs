using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponFire : MonoBehaviour {

    ObjectPooler myObjectPooler;
    float globalCD;
    float cooldown;

	// Use this for initialization
	void Start ()
    {
        myObjectPooler = GetComponent<ObjectPooler>();
        globalCD = 0.3f;
        cooldown = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1") && (cooldown <= Time.time))
        {            
            Fire();
            cooldown = Time.time + globalCD;
        }
	}

    void Fire ()
    {
        GameObject obj = myObjectPooler.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }
}
