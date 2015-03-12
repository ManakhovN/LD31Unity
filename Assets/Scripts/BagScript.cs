using UnityEngine;
using System.Collections;

public class BagScript : MonoBehaviour {
    public float offset;
    public float speed;
    public Transform target;
	void FixedUpdate () {
        transform.localScale = new Vector3(transform.position.x > target.position.x ? -1f : 1f, 1f);
        if (transform.position.x - offset > target.position.x)
            transform.position += new Vector3(-speed,0f);
        if (transform.position.x + offset < target.position.x)
            transform.position += new Vector3(speed, 0f);

	}
}
