using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    Transform focusTransform;
    Transform myTransform;
    Vector3 position;
    float smoothTime;

	void Start ()
    {
        focusTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = this.transform;
        smoothTime = 0.1f;
	}

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 goalPos = focusTransform.position;
        goalPos.z = myTransform.position.z;
        myTransform.position = Vector3.SmoothDamp(myTransform.position, goalPos, ref velocity, smoothTime);
    }
}
