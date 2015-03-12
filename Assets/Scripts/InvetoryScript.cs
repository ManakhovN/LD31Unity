using UnityEngine;
using System.Collections;

public class InvetoryScript : MonoBehaviour
{
		Queue inventory = new Queue ();

		void Start ()
		{

				inventory.Enqueue ("stone");
				Refresh ();
		}

		public void Refresh ()
		{
				IEnumerator enumerator = inventory.GetEnumerator ();
				for (int i=0; i<10; i++) {
						SpriteRenderer renderer = GameObject.Find (i.ToString ()).GetComponent<SpriteRenderer> ();
						if (i < inventory.Count && inventory.Count > 0) {
								enumerator.MoveNext ();
								renderer.sprite = Blocks.getSprite((string)enumerator.Current);
						} else
								renderer.sprite = Blocks.getSprite("none");
				}
		}

		public void Add (string s)
		{
				inventory.Enqueue (s);
				Refresh ();
		}

		public string Pull ()
		{
                if (inventory.Count == 0) return null;
				string result = inventory.Peek() as string;
				inventory.Dequeue ();
				Refresh ();
				return result;
		}
}
