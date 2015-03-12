using UnityEngine;
using System.Collections;

public class BladeScript : MonoBehaviour {
    public bool isHidden = true;
    public float time = 2f;
    float timer=0f;
    public float damage = 2f;
	void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if (timer > time)
        {
            timer = 0f;
            isHidden = !isHidden;
            this.GetComponent<Animator>().SetBool("isHidden", isHidden);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        makeDamage(coll.transform);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
            makeDamage(coll.transform);
    }

    void makeDamage(Transform coll)
    {
        Health target = coll.GetComponent<Health>();
        if (target != null && isHidden==false)
        {
            target.decreaseHealth(damage);
        }
    }
}
