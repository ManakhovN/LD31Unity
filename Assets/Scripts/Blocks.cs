using UnityEngine;
using System.Collections;

public static class Blocks{
    public static string[] names = {"box","dirt","steel","stone"};
    public static float[] durability = { 80f, 50f, 200f, 120f};
    public static float getDurability(string name){
        return durability[GetIdByName(name)];
    }

    private static int GetIdByName(string name)
    {
        for (int i = 0; i < names.Length; i++)
            if (names.Equals(name)) return i;
        return 0;
    }

    public static Sprite getSprite(string name)
    {

		Sprite[] objects = Resources.LoadAll<Sprite> ("Sprites/spriteSheet");
		foreach (Sprite i in objects)
				if (i.name.Equals(name))
						return i;
		return null;
    }
}
