using UnityEngine;
using System.Collections;

public class Laser_script : MonoBehaviour {
    public float damage = 0f;
    public float timeBetweenShoots;
    public float shootingTime;
    float timer;
    public bool isShooting = false;
	void Start () {
 /*       Vector2 vectorToTarget = -this.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        this.transform.eulerAngles = new Vector3(0, 0, angle+Random.Range(-30f,30f));*/
        if (this.transform.position.x==36f) 
            this.transform.eulerAngles = new Vector3(0,0,90f);
        else 
        if (this.transform.position.x == -36f)
            this.transform.eulerAngles = new Vector3(0, 0, 270f);
        else
        if (this.transform.position.y == 36f)
            this.transform.eulerAngles = new Vector3(0, 0, 180f);
        else
        if (this.transform.position.y == -36f)
            this.transform.eulerAngles = new Vector3(0, 0, 0f);
        if (this.damage == 0f)
        {
            Parametrs parametrs = GameObject.Find("Parametrs").GetComponent<Parametrs>();
            damage = parametrs.LaserDamage;
            timeBetweenShoots = parametrs.LaserTimeBetweenShoots;
            shootingTime = parametrs.LaserShootingTime;
        }
         
	}
	public void FixedUpdate()
	{
        
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.up, 100f);
        Transform ray = this.transform.FindChild("laser_ray");
        shootSwitcher();
        if (!isShooting && shootingTime != 0f) {
            ray.localScale = new Vector3(1f, 1f);
            return;
        }
        if (hit.collider == null)
        {
            ray.localScale = new Vector2(1f, 50f);
            return;
        }
        Health target = hit.collider.GetComponent<Health>();
        if (target != null)
            target.decreaseHealth(damage);
        ray.localScale = new Vector2(1f, hit.distance / 2f);

	}

    public void shootSwitcher()
    {
        if (timeBetweenShoots == 0) 
             return;
        timer += Time.fixedDeltaTime;
        if (isShooting)
        {
            if (timer > shootingTime)
            {
                isShooting = false;
                this.GetComponent<Animator>().SetBool("isShooting", isShooting);
                timer = 0;
            }
        }
        else
        {
            if (timer > timeBetweenShoots)
            {
                isShooting = true;
                this.GetComponent<Animator>().SetBool("isShooting", isShooting);
                timer = 0;
            }
        }
    }
}
