using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
    public static bool[,] Level = new bool[8,8];
    public void Start()
    {
        regenerate(15);
    }
    public static void regenerate(int numberOfRooms)
    {
        int p = Random.Range(0, 8);
        for (int i = 0; i < numberOfRooms; i++)
        {
            for (int j = 0; j < 8; j++)
                if (j == 7)
                {
                    Level[p, 7] = true;
                    break;
                }
                else
                    if (Level[p, j + 1] || ( p-1>=0 && Level[p - 1, j]) || ( p+1<=7 && Level[p + 1, j]))
                    {
                        Level[p, j] = true;
                        break;
                    }
            p += Random.Range(-1, 1);
            p = p < 0 ? 0 : p > 7 ? 7 : p;
        }
        bool isPlayerRemoved = false;
        Debug.Log(Level.ToString());
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if (Level[i, j])
                {
                    if (!isPlayerRemoved)
                        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3((i - 3.5f) * 112f, (j - 3.5f) * 80f, 0f);
                    Instantiate(Resources.Load("Prefabs/room"), new Vector3((i - 4) * 112, (j - 4) * 80, 0), new Quaternion(0, 0, 0, 0));
                }
         }
}
