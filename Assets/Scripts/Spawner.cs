using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float time = 0;
	void FixedUpdate () {
		time += Time.fixedDeltaTime;
		if (time>10)
		{
			Vector3 pos = new Vector3(Random.Range(-28f,28f),Random.Range(-28f,28f),0);
			Instantiate(Resources.Load ("Prefabs/Bonus"), pos,new Quaternion(0,0,0,0));
			time=0;
		}
	}
}
