using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {
    public float lifetime = 3f;
	void FixedUpdate () {
        if (lifetime != -100f)
        {
            lifetime -= Time.fixedDeltaTime;
            if (this.lifetime < 0f)
                Destroy(this.gameObject);
        }
	}

    public void setLifeTime(float _lifetime)
    {
        this.lifetime = _lifetime;
    }
}
