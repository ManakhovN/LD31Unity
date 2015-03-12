using UnityEngine;
using System.Collections;

public class Star_script : MonoBehaviour {
    void Start () {
        this.GetComponent<Animator>().speed = Random.Range(0, 2f);
	}

	void Update () {
	
	}
}
