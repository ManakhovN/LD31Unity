using UnityEngine;
using System.Collections;

public class BonusScript : MonoBehaviour {
	public float lifeTime=10;
    public bool isImmortal = false;
	public void Start()
	{

	}
	public void FixedUpdate()
	{
		lifeTime -= Time.fixedDeltaTime;
		if (this.lifeTime<0 && !isImmortal) 
			Destroy (this.gameObject);
	} 

	public void setLifeTime(float _lifeTime)
	{
		this.lifeTime = _lifeTime;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
        if (coll.tag.Equals("Player"))
        {
            int bon = Random.Range(-1, Blocks.names.Length - 1);
            if (bon == -1)
            {
                Health h = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
                h.decreaseHealth(-30f);
                if (h.getHealth() > 100f)
                    h.setHealth(100f);
                Destroy(this.gameObject);
            }
            else
            {
                InvetoryScript inventory = GameObject.Find("SideBar").GetComponent<InvetoryScript>();
                inventory.Add(Blocks.names[bon]);
                Destroy(this.gameObject);
            }
        }
	}

}
