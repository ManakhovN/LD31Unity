using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
    GameObject key; 
    void Start()
    {
        key = GameObject.Find("Main Camera/key");
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.transform.tag == "Player")
        {
            Debug.Log(key);
            key.SetActive(true);
            Destroy(this.gameObject);
        }
	}
}
