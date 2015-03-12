using UnityEngine;
using System.Collections;

public class LoadLevelOnTriggerEnter : MonoBehaviour {
    public string SceneName = null;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player" && SceneName!=null)
            Application.LoadLevel(SceneName);
    }

}
