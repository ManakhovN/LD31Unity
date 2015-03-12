using UnityEngine;
using System.Collections;

public class Atomizer : MonoBehaviour
{
		public static void Atomize (GameObject input)
		{
  			 if (input != null) {
                        Vector3 scale = input.transform.localScale;
						SpriteRenderer renderer = input.GetComponentInChildren<SpriteRenderer> ();
						Texture2D tex = renderer.sprite.texture;
						Rect texRect = renderer.sprite.rect;
						for (int i=0; i< texRect.width; i++)
								for (int j=0; j< texRect.height; j++) 
										if (tex.GetPixel (i + (int)texRect.position.x, j + (int)texRect.position.y).a >= 0.9) {
												GameObject pixel = new GameObject ();
                                                pixel.transform.localScale = scale;
												pixel.AddComponent<SpriteRenderer> ();
												SpriteRenderer pixelrenderer = pixel.GetComponent<SpriteRenderer> ();
												pixel.AddComponent<AtomMover> ();
												pixel.GetComponent<AtomMover> ().setLifeTime (3f);
												pixelrenderer.sortingLayerName = "objects";
												Texture2D newTex = new Texture2D (1, 1, tex.format, false);
												newTex.filterMode = FilterMode.Point;
												newTex.SetPixel (0, 0, tex.GetPixel (i + (int)texRect.position.x, j + (int)texRect.position.y));
												newTex.Apply ();
												pixelrenderer.sprite = Sprite.Create (newTex, new Rect (0, 0, 1, 1), new Vector2 (0.5f, 0.5f), 1);
												Vector2 pos = input.transform.position;
                                                pixel.transform.position = pos + (new Vector2(i * scale.x - texRect.width*scale.x / 2, j * scale.y - texRect.height*scale.y / 2));
										}
						Destroy (input);
				}
		}

        public static void AtomizeWithoutDestroy(GameObject input)
        {
            if (input != null)
            {
                Vector3 scale = input.transform.localScale;
                SpriteRenderer renderer = input.GetComponentInChildren<SpriteRenderer>();
                Texture2D tex = renderer.sprite.texture;
                Rect texRect = renderer.sprite.rect;
                for (int i = 0; i < texRect.width; i++)
                    for (int j = 0; j < texRect.height; j++)
                        if (tex.GetPixel(i + (int)texRect.position.x, j + (int)texRect.position.y).a >= 0.9)
                        {
                            GameObject pixel = new GameObject();
                            pixel.transform.localScale = scale;
                            pixel.AddComponent<SpriteRenderer>();
                            SpriteRenderer pixelrenderer = pixel.GetComponent<SpriteRenderer>();
                            pixel.AddComponent<AtomMover>();
                            pixel.GetComponent<AtomMover>().setLifeTime(1.5f);
                            pixelrenderer.sortingLayerName = "objects";
                            Texture2D newTex = new Texture2D(1, 1, tex.format, false);
                            newTex.filterMode = FilterMode.Point;
                            newTex.SetPixel(0, 0, tex.GetPixel(i + (int)texRect.position.x, j + (int)texRect.position.y));
                            newTex.Apply();
                            pixelrenderer.sprite = Sprite.Create(newTex, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);
                            Vector2 pos = input.transform.position;
                            pixel.transform.position = pos + (new Vector2(i * scale.x - texRect.width * scale.x / 2, j * scale.y - texRect.height * scale.y / 2));
                        }
                input.SetActive(false);
            }
        }
}
