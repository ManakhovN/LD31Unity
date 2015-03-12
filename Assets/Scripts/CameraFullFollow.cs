using UnityEngine;
using System.Collections;

public class CameraFullFollow : MonoBehaviour {
    public GameObject target;
    public Vector3 offset = new Vector3(0f,0f,-10f);
	void Start () {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
	}

	void FixedUpdate () {
       if (target!=null) 
           transform.position = target.transform.position + offset; 
	}
}
