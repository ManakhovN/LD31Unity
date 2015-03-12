using UnityEngine;
using System.Collections;
using UnityEditor;
public class GenerateTiles : MonoBehaviour {
    private static float angle = 0f;
    private static bool hasCollider = false;
    private static string Path;
    [MenuItem("MapEditor/Generate from file")]
    public static void generateFromFile()
    {
       Texture2D texture = readTextureFromFile();
       Generate(texture);
    }
    
    private static Texture2D readTextureFromFile()
    {
        Texture2D texture = new Texture2D(0, 0);
        string  path = EditorUtility.OpenFilePanel("Select source image", "", "png");
        if (path.Length != 0)
        {
            Path = "file:///" + path;
            WWW www = new WWW("file:///" + path);
            www.LoadImageIntoTexture(texture);
        }
        return texture;
    }

    [MenuItem("MapEditor/Refresh")]
    public static void Refresh()
    {
        Texture2D texture = readTextureByPath();
        Generate(texture);
    }

    private static Texture2D readTextureByPath()
    {
        DestroyImmediate(GameObject.Find("map"));
        Texture2D texture = new Texture2D(0, 0);
        if (Path!= null)
        {       
            WWW www = new WWW(Path);
            www.LoadImageIntoTexture(texture);
        }
        return texture;
    }

    private static void Generate(Texture2D texture)
    { 
        GameObject obj = new GameObject("map");
        for (int i=0; i<texture.width; i++)
            for (int j = 0; j < texture.height; j++)
            {
                if (!texture.GetPixel(i, j).Equals(new Color(0, 0, 0)))
                { 
                    GameObject tile = new GameObject("tile_"+i+"_"+j);
                    tile.transform.position=new Vector3(i*8,j*8);
  //                  tile.layer = 2;
                    tile.AddComponent<SpriteRenderer>();
                    tile.GetComponent<SpriteRenderer>().sprite = getTile(texture,i,j);
                    tile.GetComponent<SpriteRenderer>().material = Resources.Load("Materials/SpriteMaterial",typeof(Material)) as Material;
                    tile.transform.localRotation = Quaternion.Euler(0f,0f,angle);
                    tile.transform.SetParent(obj.transform);
                    if (hasCollider) tile.AddComponent<BoxCollider2D>();
                }
            }
    }

    private static Sprite getTile(Texture2D texture, int x, int y)
    {
        hasCollider = false;
        angle = 0f;
        bool[,] pix = new bool[3,3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                 pix[i, j] = !texture.GetPixel(x + i - 1, y + j - 1).Equals(Color.black);
        if (isMatrixEquals(pix, "?ff?tf???") ||
            isMatrixEquals(pix, "ff?ft????") ||
            isMatrixEquals(pix, "???ft?ff?") ||
            isMatrixEquals(pix, "????tf?ff") ||
            isMatrixEquals(pix, "ftttttttt") ||
            isMatrixEquals(pix, "ttftttttt") ||
            isMatrixEquals(pix, "ttttttftt") ||
            isMatrixEquals(pix, "ttttttttf"))
            {
                hasCollider = true;
                return getSprite("fields_angle");
            }
        if (isMatrixEquals(pix, "ttttttttt")) 
            return getSprite("fields_inside");
        if (isMatrixEquals(pix, "?t??t??t?"))
            angle = 90f;
        hasCollider = true;
        return getSprite("fields_side");
    }
    private static Sprite getSprite(string name)
    {

        Sprite[] objects = Resources.LoadAll<Sprite>("Sprites/spriteSheet");
        foreach (Sprite i in objects)
            if (i.name.Equals(name))
                return i;
        return null;
    }

    private static bool isMatrixEquals(bool[,] matrix, string s)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (matrix[i, 2-j] != (s[j * 3 + i] == 't') && s[j*3+i]!='?') return false;
       return true;
    }
}
