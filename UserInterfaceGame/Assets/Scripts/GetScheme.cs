using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GetScheme : MonoBehaviour
{
    public bool left = false, right = true, controller = false, CC = false;

    private TextMeshProUGUI CCTextBox;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        CCTextBox = GameObject.FindGameObjectWithTag("CCText").GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game_0")
        {
            CCTextBox = null;
            CCTextBox = GameObject.FindGameObjectWithTag("CCText").GetComponent<TextMeshProUGUI>();
        }
    }

    public void AddSoundText(string sound)
    {

        //check if there are > 6  lines of sounds displayed
        string[] lines = CCTextBox.text.Split('\n');
        string newText = sound;
        if (lines.Length >= 3)
        {
            //if so then copy the current text
            for(int i = 0; i < 2; i ++)
            {
                newText += ('\n' +lines[i]);
            }

        }
        else
        {
            //just add append a line
            foreach (string line in lines)
            {
                newText += ('\n' + line);
            }
        }

        CCTextBox.text = newText;

        //potentially run timer to clear box after x amount of seconds
    }

    public void ClosedCaptioningOn()
    {
        CC = true;
    }


    public void ClosedCaptioningOff()
    {
        CC = false;
    }

    public void SetControlScheme(string scheme, bool on)
    {
        if (scheme == "Left")
        {
            left = true;
            right = false;
            controller = false;
            
        }
        else if (scheme == "Right")
        {
            left = false;
            right = true;
            controller = false;
        }
        else if (scheme == "Controller")
        {
            left = false;
            right = false;
            controller = true;
        }      
    }

    public string GetCurrentScheme()
    {
        if (left == true)
        {
            return "Left";
        }

        if (right == true)
        {
            return "Right";
        }

        if (controller == true)
        {
            return "Controller";
        }
        return " ";
    }

}
