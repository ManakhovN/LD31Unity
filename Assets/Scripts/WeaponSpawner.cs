using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour {
    public float time=0f;
    int mode=0;
    int iteration = 1;
	void FixedUpdate () {
        time += Time.fixedDeltaTime;
        if (time > 7f)
        {
            time = 0f;
            switch (mode)
            { 
                case 0:
                    int throwACoin = Random.Range(-50, 50);
                    int x = Random.Range(-50, 50) >= 0 ? 36 : -36;
                    int y = Random.Range(-50, 50) >= 0 ? 36 : -36;
                    if (throwACoin >= 0) x = Random.Range(-34,34); 
                        else y = Random.Range(-30,30);
                    Instantiate(Resources.Load("Prefabs/Laser"), new Vector3(x,y), new Quaternion(0,0,0,0));
                    break;
                case 1:
                    x = Random.Range(-35,35);
                    y = Random.Range(-35, 35);
                    Instantiate(Resources.Load("Prefabs/thrower") , new Vector3(x,y), new Quaternion(0,0,0,0));
                    break;
                case 2:
                    for (int i=0; i<iteration; i++){
                        x = Random.Range(-35,35);
                        y = Random.Range(-35, 35);
                        Instantiate(Resources.Load("Prefabs/Rocket_shadow") , new Vector3(x,y), new Quaternion(0,0,0,0));
                    }
                    break;
                case 3:
                    for (int i = 0; i < iteration; i++)
                    {
                        x = Random.Range(-35, 35);
                        y = Random.Range(-35, 35);
                        Instantiate(Resources.Load("Prefabs/Spider_shadow"), new Vector3(x, y), new Quaternion(0, 0, 0, 0));
                    }
                    break;
                case 4:
                    mode = -1;
                    iteration++;
                    break;
                case 5:
                    break;
            }
            mode++;
        }
	}
}
