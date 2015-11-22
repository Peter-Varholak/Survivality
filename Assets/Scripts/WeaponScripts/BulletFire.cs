using UnityEngine;
using System.Collections;

public class BulletFire : MonoBehaviour {

    Transform myTransform;
    public float bulletSpeed = 2.5f;
    Vector2 shootDirection;

    void Awake ()
    {
        myTransform = this.transform;
    }

	// Use this for initialization
	void OnEnable ()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        shootDirection = (clickPosition - (Vector2)myTransform.position);
        shootDirection.Normalize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shoot();
	}

    void Shoot()
    {
        float x = shootDirection.x * bulletSpeed * Time.deltaTime;
        float y = shootDirection.y * bulletSpeed * Time.deltaTime;

        myTransform.position += new Vector3(x, y);
    }
}
