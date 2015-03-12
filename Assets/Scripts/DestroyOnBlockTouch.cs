using UnityEngine;
using System.Collections;

public class DestroyOnBlockTouch : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll)
    {
        isBlockTouched(coll.transform);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        isBlockTouched(coll.transform);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        isBlockTouched(coll.transform);
    }

    void isBlockTouched(Transform transform)
    {
        if (transform.tag.Equals("Block"))
            Atomizer.Atomize(this.gameObject);
    }
}
