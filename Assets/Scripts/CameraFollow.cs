using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    public float time=1f;
    public Vector3 offset = new Vector3(2f,2f);
	void Start () {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       if (transform.position.x>target.transform.position.x + offset.x)
           transform.position -= new Vector3(time,0f);
       if (transform.position.x < target.transform.position.x - offset.x)
           transform.position -= new Vector3(-time, 0f);
	}
}
