using UnityEngine;
using System.Collections;

public class Bomb_fall : MonoBehaviour {
    void Update()
    {
        if (transform.Find("rocket").transform.localPosition.y <= 0f)
        {
            GameObject bomb = Instantiate(Resources.Load("Prefabs/explosion"), this.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
            Parametrs parametrs = GameObject.Find("Parametrs").GetComponent<Parametrs>();
            bomb.GetComponent<Damager>().damage = parametrs.ExplosionDamage;
            Destroy(this.gameObject);
        }
    }
}
