using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

		void FixedUpdate ()
		{
			GameObject player = GameObject.Find ("Player");
			if (player != null) {
					Health health = player.GetComponent<Health> ();
					transform.localScale = new Vector3 (health.getHealth () / 100f, 1f, 1f);
				}
			else 
				transform.localScale = new Vector3 (0f, 1.25f, 1f);

		}
}
