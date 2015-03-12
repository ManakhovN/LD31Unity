using UnityEngine;
using System.Collections;

public class ThrowerRotate : MonoBehaviour {
	float time=0;
	void FixedUpdate () {
		time += Time.fixedDeltaTime;
		if (time > 0.1) {
			time=0;
			this.transform.Rotate(new Vector3(0,0,90));
		}
	}
}
