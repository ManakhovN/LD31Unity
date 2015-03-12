using UnityEngine;
using System.Collections;

public class DestroyAndDamage : MonoBehaviour {
    public float damage;
    void OnCollisionEnter2D(Collision2D coll)
    {
        DamageAndDestroy(coll.transform);
    }

    void OnColliderEnter2D(Collider2D coll)
    {
        DamageAndDestroy(coll.transform);
    }

    void DamageAndDestroy(Transform coll)
    {
        Health target = coll.transform.GetComponent<Health>();
        if (target != null)
            target.decreaseHealth(damage);
        Atomizer.Atomize(this.gameObject);
    }
}
