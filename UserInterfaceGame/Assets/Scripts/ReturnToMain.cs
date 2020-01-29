using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    GameObject returnButton;
    private void Start()
    {
        returnButton = GameObject.FindGameObjectWithTag("ReturnButton");
        returnButton.SetActive(false);
    }


    public void Return()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
