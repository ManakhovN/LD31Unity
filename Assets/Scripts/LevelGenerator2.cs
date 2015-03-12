using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelGenerator2 : MonoBehaviour {
    public int maximum = 3;
    public bool[,] rooms = new bool[20, 20];
    List<Vector2> availableTiles = new List<Vector2>();
	void Start () {
         availableTiles.Add(new Vector2(10,10));
         regenerate(maximum, 10, 10);
         this.GetComponent<PlayerController>().drawRoomsWhichAreVisible();
     }

    public void regenerate(int numberOfRooms, int x, int y)
    {
        for (int i = 0; i <= numberOfRooms; i++) 
        if  (availableTiles.Count>0)
        { 
               Vector2 picked = pickAFreeTile();
               if (picked.x<20 & picked.y<20) rooms[(int)picked.x, (int)picked.y] = true;
       }
    }
    public  Vector2 pickAFreeTile()
    {
        int num = Random.Range(0,availableTiles.Count);
        Vector2 picked = availableTiles[num];
        if (picked.x - 1 >= 0) AddAvailableTile(new Vector2(picked.x-1,picked.y));
        if (picked.x + 1 < 20) AddAvailableTile(new Vector2(picked.x + 1, picked.y));
        if (picked.y - 1 >= 0) AddAvailableTile(new Vector2(picked.x, picked.y - 1));
        if (picked.y + 1 < 20) AddAvailableTile(new Vector2(picked.x, picked.y + 1));
        availableTiles.RemoveAt(num);
        return picked;
    }

    public void AddAvailableTile(Vector2 tile)
    { 
        bool available=true;
        for (int i = 0; i < availableTiles.Count; i++)
            if (availableTiles[i].x == tile.x && availableTiles[i].y == tile.y)
            {
                available = false;
            }
        if (available) availableTiles.Add(tile);
    }
}
