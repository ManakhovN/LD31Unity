using UnityEngine;
using System.Collections;

public class Spider_fall : MonoBehaviour {

	void Update () {
        if (transform.Find("spider").transform.localPosition.y <= 3f) {
          GameObject spider = Instantiate(Resources.Load("Prefabs/spider"), this.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
          Parametrs parametrs = GameObject.Find("Parametrs").GetComponent<Parametrs>();
          spider.GetComponent<DestroyAndDamage>().damage = parametrs.SpiderDamage;
          Destroy(this.gameObject);
        }	
	}
}
