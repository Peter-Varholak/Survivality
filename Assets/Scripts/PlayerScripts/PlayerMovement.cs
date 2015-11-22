using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Transform myTransform;

    public float MoveSpeed { get; set; }

    void Awake ()
    {
        myTransform = this.transform;
    }

	// Use this for initialization
	void Start ()
    {
        MoveSpeed = 2.5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    void Move ()
    {
        float v = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        float h = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;

        myTransform.Translate(new Vector3(h, v, 0));
    }
}
