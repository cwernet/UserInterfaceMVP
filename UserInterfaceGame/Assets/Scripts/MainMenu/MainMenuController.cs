using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject mainMenu;
    GameObject infoMenu;
    GameObject creditsMenu;
    GameObject schemeMenu;
    GetScheme schemeGetter;
    public TextMeshProUGUI mvmtText, firetxt;

    public AudioClip click;
    public AudioClip start;
    public AudioClip pause;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void Awake()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        string nameScene = SceneManager.GetActiveScene().name;
        if (nameScene == "Game_0")
        {
            mainMenu.SetActive(false);
        }
        infoMenu = GameObject.FindGameObjectWithTag("InfoMenu");
        schemeGetter = GameObject.FindGameObjectWithTag("SchemeGetter").GetComponent<GetScheme>();
        // set current control scheme text
        mvmtText.text = "W - Right \n A - Left \n S - Down \n D - UP ";
        firetxt.text = "Fire Weapons \nLeft Click\n\n\nSelect/Equip items click";
        if (schemeGetter != null)
        {
            if (schemeGetter.GetCurrentScheme() == "Left")
            {
                mvmtText.text = "Right Arrow - Right \n Left Arrow - Left \n Down Arrow - Down \n Up Arrow - UP ";
                firetxt.text = "Fire Weapons \nLeft Click\n\n\nSelect/Equip items click";
            }
            else if (schemeGetter.GetCurrentScheme() == "Controller")
            {
                mvmtText.text = "B - Right \n X - Left \n A - Down \n Y - UP ";
                firetxt.text = "Fire Weapons \n'RT'\n\n\nSelect/Equip items 'RT'";
            }
        }
        creditsMenu = GameObject.FindGameObjectWithTag("CreditsMenu");
        schemeMenu = GameObject.FindGameObjectWithTag("SchemeMenu");
        schemeMenu.SetActive(false);
        infoMenu.SetActive(false);
        creditsMenu.SetActive(false);

        

        //movement stuff
 
        //mvmtText = GameObject.FindGameObjectWithTag("MvmtText").GetComponent<TextMeshProUGUI>();
    }

    public void PlayGame()
    {
        source.PlayOneShot(start);
        schemeGetter.AddSoundText("Bling!");
        SceneManager.LoadScene("Game_0");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowInfoScreen()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        mainMenu.SetActive(false);
        schemeMenu.SetActive(false);
        infoMenu.SetActive(true);

        if (schemeGetter != null)
        {
            if (schemeGetter.GetCurrentScheme() == "Left")
            {
                mvmtText.text = "Right Arrow - Right \n Left Arrow - Left \n Down Arrow - Down \n Up Arrow - UP ";
                firetxt.text = "Fire Weapons \nLeft Click\n\n\nSelect/Equip items click";
            }
            else if (schemeGetter.GetCurrentScheme() == "Controller")
            {
                mvmtText.text = "B - Right \n X - Left \n A - Down \n Y - UP ";
                firetxt.text = "Fire Weapons \n'RT'\n\n\nSelect/Equip items 'RT'";
            }
            else
            {
                //right
                mvmtText.text = "W - Right \n A - Left \n S - Down \n D - UP ";
                firetxt.text = "Fire Weapons \nLeft Click\n\n\nSelect/Equip items click";
            }
        }
    }

    public void ShowMainMenu()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        mainMenu.SetActive(true);       
        infoMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void ShowCredits()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ShowSchemeMenu()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        infoMenu.SetActive(false);
        schemeMenu.SetActive(true);
    }

    public void ContinueButton()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        source.PlayOneShot(pause);
        schemeGetter.AddSoundText("Bloop...");
        Time.timeScale = 0;
        mainMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    public void ReturnToTitle()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
        Destroy(GameObject.FindGameObjectWithTag("BGMusic"));
    }


    public void SetLeftScheme()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        schemeGetter.SetControlScheme("Left", true);
        mvmtText.text = "Right Arrow - Right \n Left Arrow - Left \n Down Arrow - Down \n Up Arrow - UP ";
        firetxt.text = "Fire Weapons \nLeft Click\n\n\nSelect/Equip items click";
    }

    public void SetRightScheme()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        schemeGetter.SetControlScheme("Right", true);
        mvmtText.text = "W - Right \n A - Left \n S - Down \n D - UP ";
        firetxt.text = "Fire Weapons \nLeft Click\n\n\nSelect/Equip items click";
    }

    public void SetControllerScheme()
    {
        source.PlayOneShot(click);
        schemeGetter.AddSoundText("Click...");
        schemeGetter.SetControlScheme("Controller", true);
        mvmtText.text = "B - Right \n X - Left \n A - Down \n Y - UP ";
        firetxt.text = "Fire Weapons \n'RT'\n\n\nSelect/Equip items 'RT'";
    }

}
