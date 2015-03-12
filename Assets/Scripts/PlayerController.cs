using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
		public GameObject player;
		public float speedScale;
        public bool ShowScore;
		private Animator animator;
		private int way;
        GameObject[,] roomObjects = null;
        GameObject currentRoom = null;
        GameObject top = null, bot = null, left = null, right = null;
		void Start ()
		{
            bool haveKey= GameObject.Find("Parametrs").GetComponent<Parametrs>().IsPlayerHaveKeyAtGameStart;
			if (GameObject.Find("Main Camera/key")!=null) 
                GameObject.Find("Main Camera/key").SetActive(haveKey);
                if (player == null) 
						player = GameObject.FindGameObjectWithTag ("Player");
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
            drawRoomsWhichAreVisible();
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.LoadLevel(0);
            }

            if (player == null || player.GetComponent<Health>().getHealth() <= 0)
            {
                if (ShowScore)
                {
                    float score = GameObject.Find("Canvas/Panel/Score").GetComponent<ScoreScript>().GetScore();
                    Text text = GameObject.Find("Canvas/Panel/End").GetComponent<Text>();
                    text.text = "You are dead \n Your Score is: " + (int)(score * 100);
                }
                else Application.LoadLevel(0);
            }
				if (player != null) {
						animator = player.GetComponent<Animator> ();
						float horizontal = Input.GetAxis ("Horizontal");
						float vertical = Input.GetAxis ("Vertical");
						player.rigidbody2D.velocity = new Vector3 (horizontal * speedScale, vertical * speedScale, 0);
						if (animator != null)
								setWay (horizontal, vertical);
						if (animator.GetInteger ("Way") != 0)
								way = animator.GetInteger ("Way");
						if (Input.GetKey (KeyCode.Q))
								player.GetComponent<Health> ().decreaseHealth (3);
	
						if (Input.GetButtonDown ("Fire1"))
								putBlock ();
				} else
						player = GameObject.FindGameObjectWithTag ("Player");
		}

		public void putBlock ()
		{
				string blockName = GameObject.Find ("SideBar").GetComponent<InvetoryScript> ().Pull ();
				if (blockName != null) {
						GameObject block = Instantiate (Resources.Load ("Prefabs/Box"), player.transform.position + getOffset (), new Quaternion (0, 0, 0, 0)) as GameObject;
						block.GetComponent<Health> ().setHealth (Blocks.getDurability (blockName));
						block.GetComponent<SpriteRenderer> ().sprite = Blocks.getSprite (blockName);
                        if (currentRoom != null)
                            block.transform.SetParent(currentRoom.transform);
				}
		}

		public void setWay (float horizontal, float vertical)
		{
				if (vertical > 0 && Mathf.Abs (vertical) > Mathf.Abs (horizontal))
						animator.SetInteger ("Way", 2);
				else
                if (vertical < 0 && Mathf.Abs (vertical) > Mathf.Abs (horizontal))
						animator.SetInteger ("Way", 1);
				else
                    if (horizontal < 0)
						animator.SetInteger ("Way", 3);
				else
                        if (horizontal > 0)
						animator.SetInteger ("Way", 4);
				else
						animator.SetInteger ("Way", 0);
		}

		public Vector3 getOffset ()
		{
				switch (way) { 
				case 1:
						return new Vector3 (0f, -7f);
				case 2:
						return new Vector3 (0f, 7f);
				case 3:
						return new Vector3 (-6f, 0f);
				case 4:
						return new Vector3 (6f, 0f);
				}
				return new Vector3 (0f, 0f);
		}

        public void drawRoomsWhichAreVisible()
        {
            if (this.GetComponent<LevelGenerator2>() == null || player==null) return;
            bool[,] rooms = this.GetComponent<LevelGenerator2>().rooms;
            if (roomObjects == null)
            {
                roomObjects = new GameObject[20, 20];
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 20; j++)
                        if (rooms[i, j])
                        {
                            roomObjects[i, j] = Instantiate(Resources.Load("Prefabs/room"), new Vector3((i - 10) * 112 - 56, (j - 10) * 80 - 40, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                            if (i - 1 > 0 && rooms[i - 1, j]) roomObjects[i, j].transform.FindChild("Left").gameObject.SetActive(false);
                            if (i + 1 < 19 && rooms[i + 1, j]) roomObjects[i, j].transform.FindChild("Right").gameObject.SetActive(false);
                            if (j - 1 > 0 && rooms[i, j - 1]) roomObjects[i, j].transform.FindChild("Bot").gameObject.SetActive(false);
                            if (j + 1 < 19 && rooms[i, j + 1]) roomObjects[i, j].transform.FindChild("Top").gameObject.SetActive(false);
                            roomObjects[i, j].SetActive(false);
                        }
            }
            else
            {
                int i = (int)(player.transform.position.x / 112f + 10.5f);
                int j=  (int)(player.transform.position.y / 80f + 10.5f);
                   setAdjacentRoomActive(false);
                   roomObjects[i, j].SetActive(true);
                   currentRoom = roomObjects[i, j];
                   top = roomObjects[i,j+1];
                   bot = roomObjects[i , j-1];
                   left = roomObjects[i - 1, j];
                   right = roomObjects[i + 1, j];
                   setAdjacentRoomActive(true);
                
            }
        }
        public void setAdjacentRoomActive(bool active)
        {
            if (top != null) top.SetActive(active);
            if (bot != null) bot.SetActive(active);
            if (left != null) left.SetActive(active);
            if (right != null) right.SetActive(active);
        }
}
