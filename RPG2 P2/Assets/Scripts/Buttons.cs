using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;

    public GameObject levelSelect;
    public GameObject quit;
    public GameObject tutorial;
    public bool menuSelect;
    public bool tutorialOn;
    public GameObject tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        l1.SetActive(false);
        l2.SetActive(false);
        l3.SetActive(false);
        l4.SetActive(false);
        l5.SetActive(false);
        menuSelect = false;
        tutorialOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuSelect == true)
            {
                l1.SetActive(false);
                l2.SetActive(false);
                l3.SetActive(false);
                l4.SetActive(false);
                l5.SetActive(false);
                menuSelect = false;
                levelSelect.SetActive(true);
                quit.SetActive(true);
                tutorial.SetActive(true);
            }
            if (tutorialOn == true)
            {
                tutorialText.SetActive(false);
                levelSelect.SetActive(true);
                quit.SetActive(true);
                tutorial.SetActive(true);
                tutorialOn = false;
            }
        }
    }

    public void ChooseLevel()
    {
        l1.SetActive(true);
        l2.SetActive(true);
        l3.SetActive(true);
        l4.SetActive(true);
        l5.SetActive(true);
        menuSelect = true;
        levelSelect.SetActive(false);
        quit.SetActive(false);
        tutorial.SetActive(false);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(6);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        tutorialText.SetActive(true);
        tutorialOn = true;
        tutorial.SetActive(false);
        levelSelect.SetActive(false);
        quit.SetActive(false);
    }
}
