using UnityEngine;
using System.Collections;

public class CutsceneNil : MonoBehaviour {
    GameObject UFO;

    int moveNumber;
    float localCounter = 0f;
    void Start()
    {
        moveNumber = 0;
        UFO = GameObject.Find("UFO");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (moveNumber)
        {
            case 0:
                wait(3f);
                break;
            case 1:
                moveLeft(UFO.transform, 0.5f);
                moveDown(UFO.transform, 0.5f);
                wait(1f);
                break;
            case 2:
                moveLeft(UFO.transform, 0.4f);
                wait(4.7f);
                break;
            case 3:
                wait(2f);
                break;
            case 4:
                Application.LoadLevel("cutscene1");
                break;            
        }
    }

    void upMoveNumber()
    {
        moveNumber++;
        localCounter = 0f;
    }

    void moveRight(Transform gObj, float delta)
    {
        gObj.position += new Vector3(delta, 0);
    }

    void moveLeft(Transform gObj, float delta)
    {
        gObj.position -= new Vector3(delta, 0);
    }


    void moveUp(Transform gObj, float delta)
    {
        gObj.position += new Vector3(0, delta);
    }

    void moveDown(Transform gObj, float delta)
    {
        gObj.position -= new Vector3(0, delta);
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
