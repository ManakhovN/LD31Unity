using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {
    float score=0f;
    GameObject target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
	void FixedUpdate () {
        if (target!=null)
        {
            score += Time.fixedDeltaTime;
            this.GetComponent<Text>().text = "SCORE:" + (int)(score * 100);
        }
	}

    public float GetScore()
    {
        return score;
    }
}
