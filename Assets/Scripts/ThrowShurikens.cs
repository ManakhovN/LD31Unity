using UnityEngine;
using System.Collections;

public class ThrowShurikens : MonoBehaviour {
    float time=0f;
    public float maxtime;
    void FixedUpdate () {
        time += Time.deltaTime;
        if (time > maxtime)
        {
            time = 0;
            for (int i=-1; i<=1; i+=2)
                for (int j = -1; j <= 1; j += 2)
                {
                    GameObject shuriken = Instantiate(Resources.Load("Prefabs/shuriken"), this.transform.position, new Quaternion(0,0,0,0)) as GameObject;
                    shuriken.GetComponent<Mover>().setOffSet(new Vector3(i,j));
                    Parametrs parametrs = GameObject.Find("Parametrs").GetComponent<Parametrs>();
                    shuriken.GetComponent<Damager>().damage = parametrs.ShurikenDamage;
                }
        }
	}
}
