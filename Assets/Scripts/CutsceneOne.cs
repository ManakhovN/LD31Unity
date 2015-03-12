using UnityEngine;
using System.Collections;

public class CutsceneOne : MonoBehaviour {
    GameObject alien;
    GameObject player;
    GameObject bag;
    GameObject light;
    GameObject TV;
    int moveNumber;
    float localCounter = 0f;
	void Start () {
        moveNumber = 0;
        TV = GameObject.Find("TV");
        alien = GameObject.Find("alien");
        bag = GameObject.Find("bag");
        light = GameObject.Find("alien_light");
        player = GameObject.Find("sleep");
        alien.SetActive(false);
        light.SetActive(false);
        bag.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        switch (moveNumber)
        { 
            case 0:
                wait(3f);
                break;
            case 1:
                light.SetActive(true);
                upMoveNumber();
                break;
            case 2:
                wait(3f);
                break;
            case 3:
                openDoor();
                upMoveNumber();
                break;
            case 4:
                wait(0.5f);
                break;
            case 5:
                alien.SetActive(true);
                upMoveNumber();
                break;
            case 6:
                wait(0.5f);
                break;
            case 7:
                alien.GetComponent<Animator>().SetInteger("Way", 3);
                upMoveNumber();
                break;
            case 8:
                moveLeft(alien.transform,0.2f,new Vector2(9f,0f));
                break;
            case 9:
                alien.GetComponent<Animator>().SetInteger("Way", 2);
                upMoveNumber();
                break;
            case 10:
                alien.GetComponent<Animator>().SetInteger("Way", 0);
                upMoveNumber();
                break;
            case 11:
                alien.GetComponent<Animator>().SetInteger("Way", 4);
                bag.SetActive(true);
                player.SetActive(false);
                upMoveNumber();
                break;
            case 12:
                moveRight(alien.transform, 0.2f, new Vector2(53.5f, 0f));
                break;
            case 13:
                alien.SetActive(false);
                bag.SetActive(false);
                light.SetActive(false);
                upMoveNumber();
                break;
            case 14:
                alien.SetActive(true);
                bag.transform.position = new Vector3(31f,bag.transform.position.y);
                upMoveNumber();
                alien.GetComponent<Animator>().SetInteger("Way", 3);
                break;
            case 15:
                moveLeft(alien.transform, 0.2f, new Vector2(30f,0f));
                break;
            case 16:
                alien.GetComponent<Animator>().SetInteger("Way", 4);
                bag.SetActive(true);
                TV.SetActive(false);
                upMoveNumber();
                break;
            case 17:
                moveRight(alien.transform, 0.2f, new Vector2(53.5f, 0f));
                break;
            case 18:
                bag.SetActive(false);
                alien.SetActive(false);
                upMoveNumber();
                break;
            case 19:
                wait(0.5f);
                break;
            case 20:
                closeDoor();
                upMoveNumber();
                break;
            case 21:
                wait(1f);
                break;
            case 22:
                Debug.Log("End of scene");
                Application.LoadLevel("level1");
                break;
            
        }
	}

    private void openDoor()
    {
        GameObject door = GameObject.Find("door");
        door.GetComponent<SpriteRenderer>().sprite = Blocks.getSprite("opened_door");
    }

    private void closeDoor()
    {
        GameObject door = GameObject.Find("door");
        door.GetComponent<SpriteRenderer>().sprite = Blocks.getSprite("door");
    }

    void upMoveNumber()
    {
        moveNumber++;
        localCounter = 0f;
    }

    void moveRight(Transform gObj, float delta)
    {
        gObj.position += new Vector3(delta,0);
    }

    void moveLeft(Transform gObj, float delta)
    {
        gObj.position -= new Vector3(delta, 0);
    }

    void moveRight(Transform gObj, float delta, Vector2 finalPosition)
    {
        gObj.position += new Vector3(delta, 0);
        if (gObj.position.x > finalPosition.x)
            upMoveNumber();
    }

    void moveLeft(Transform gObj, float delta, Vector2 finalPosition)
    {
        gObj.position -= new Vector3(delta, 0);
        if (gObj.position.x < finalPosition.x)
            upMoveNumber();
    }

    void wait(float delta)
    {
        localCounter += Time.fixedDeltaTime;
        if (localCounter >= delta)
            upMoveNumber();
    }

}
