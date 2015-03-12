using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float rotateSpeed=1f;
	void FixedUpdate () {
        this.transform.Rotate(0,0,rotateSpeed);
	}
}
