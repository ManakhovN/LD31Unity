using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health=100;	

	public void setHealth(float _health)
	{
		this.health = _health;
	}

	public float getHealth()
	{
		return this.health;
	}

	public void decreaseHealth(float delta)
	{
		health -= delta;
		if (health <= 0) {
			Atomizer.Atomize(this.gameObject);
		}
	}

}
