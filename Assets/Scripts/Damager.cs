using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour {
    public float damage;
    public bool damageOnlyOnEnter = true;
    void OnTriggerEnter2D(Collider2D coll)
    {
            makeDamage(coll.transform);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (damageOnlyOnEnter == false) {
            makeDamage(coll.transform);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (damageOnlyOnEnter == false)
        {
            makeDamage(coll.transform);
        }
    }
    void makeDamage(Transform coll)
    {
        Health target = coll.GetComponent<Health>();
        if (target != null)
        {
            target.decreaseHealth(damage);
        }
    }

    void SelfDestruction()
    {
        Destroy(this.gameObject);
    }
}
