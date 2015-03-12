using UnityEngine;
using System.Collections;

public class AtomMover : MonoBehaviour
{
		private float accelerationY = 0.04f;
		public float lifeTime = 5;
		public float velocityX, velocityY;

		public void setLifeTime (float lifeTime_)
		{
				this.lifeTime = lifeTime_;
		}

		void Start ()
		{
				velocityX = Random.Range (-0.4f, 0.4f);
				velocityY = Random.Range (-0.2f, 0.7f);
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				lifeTime -= Time.fixedDeltaTime;
				velocityY -= accelerationY;
				this.transform.position = new Vector2 (transform.position.x + velocityX, transform.position.y + velocityY);
				if (lifeTime < 0)
						Destroy (this.gameObject);
		}
}
