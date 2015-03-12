using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public Vector3 offset = new Vector3(0, 0, 0);
	void FixedUpdate () {
        this.transform.position += offset;	
	}

    public void setOffSet(Vector3 _offset)
    {
        this.offset = _offset;
    }
}
