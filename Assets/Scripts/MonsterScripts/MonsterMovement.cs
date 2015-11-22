using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

    Transform myTransform;
    Transform target;
    public float MoveSpeed { get; set; }

    void Awake ()
    {
        myTransform = this.transform;
    }

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        MoveSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveTowardsPlayer();
	}

    void MoveTowardsPlayer ()
    {
        myTransform.position = Vector3.MoveTowards(myTransform.position, target.position, MoveSpeed * Time.deltaTime);
    }
}
