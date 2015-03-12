using UnityEngine;
using System.Collections;

public class Gate_script : MonoBehaviour
{
    public void Suicide()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player" && GameObject.Find("Main Camera/key")!=null && GameObject.Find("Main Camera/key").activeSelf)
        {
            this.GetComponent<Animator>().SetBool("Open", true);
            GameObject.Find("Main Camera/key").SetActive(false);
        }
    }
}
