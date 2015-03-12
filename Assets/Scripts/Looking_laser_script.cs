using UnityEngine;
using System.Collections;

public class Looking_laser_script : MonoBehaviour
{
    public float damage = 0f;
    public float timeBetweenShoots;
    public float shootingTime;
    float timer;
    public bool isShooting = false;
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        Vector3 targetPoint = ray.GetPoint(hitdist);
        targetPoint =new Vector3(this.transform.position.x,targetPoint.y , 0f);
        this.transform.position=targetPoint;
        Shoot();
    }

    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.up, 100f);
        Transform ray = this.transform.FindChild("laser_ray");
        shootSwitcher();
        if (!isShooting && shootingTime != 0f)
        {
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