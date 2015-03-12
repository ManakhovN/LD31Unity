using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
    public GameObject target=null;
    public float delta = 1f;
    public float maxDistance = 0f;
	void Start () {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target != null)
        {
            if (maxDistance > 0.5f && (target.transform.position - this.transform.position).sqrMagnitude > maxDistance)
                return;
            this.transform.position = Vector2.Lerp(this.transform.position, target.transform.position, delta);
        }
    }
}
