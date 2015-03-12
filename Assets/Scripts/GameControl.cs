using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
    string picked = null;
    float timer = 0f;
    GameObject MainMenu;
    GameObject HelpMenu;
    GameObject HelpButton;
    GameObject AboutButton;
    GameObject BackButton;
    GameObject BackMenu;
    GameObject AboutMenu;
    void Start()
    {
        MainMenu = GameObject.Find("MainMenu");
        HelpMenu = GameObject.Find("HelpMenu");
        HelpButton = GameObject.Find("MainMenu/MainButtons/Help");
        AboutButton = GameObject.Find("MainMenu/MainButtons/About");
        BackButton = GameObject.Find("Back");
        AboutMenu = GameObject.Find("AboutMenu");
        ActivateMainMenu();
        HelpMenu.SetActive(false);
        BackButton.SetActive(false);
    }
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }

        if (picked != null)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 1f)
            {
                 if (picked.Equals("Survival Mode"))
                     Application.LoadLevel("SurvivorMode");
                 if (picked.Equals("Story Mode"))
                     Application.LoadLevel("cutscene0");
                if (picked.Equals("About"))
                 {
                     MainMenu.SetActive(false);
                     AboutMenu.SetActive(true);
                     BackButton.SetActive(true);
                 }
                 if (picked.Equals("Help"))
                 {
                     MainMenu.SetActive(false);
                     HelpMenu.SetActive(true);
                     BackButton.SetActive(true);
                 }
                 if (picked.Equals("Exit"))
                     Application.Quit();
                 if (picked.Equals("Back"))
                 {
                     ActivateMainMenu();
                 }
                timer = 0f;
                picked = null;
            }
        }
	}

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            picked = hit.collider.gameObject.name;
            Atomizer.AtomizeWithoutDestroy(hit.collider.gameObject);
        }
    }

    void ActivateMainMenu()
    {
        MainMenu.SetActive(true);
        HelpMenu.SetActive(false);
        AboutMenu.SetActive(false);
        HelpButton.SetActive(true);
        AboutButton.SetActive(true);
        BackButton.SetActive(false);
    }
}
