using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Singleton : MonoBehaviour
{
    public Transform canoe;
    public Slider progressSlider;
    public Transform endCube;
    GameObject[] enemyTurrets;
    public float totalEnemies, curEnemies;
    public float progressLength, curlenght;


    // Start is called before the first frame update
    void Start()
    {
        enemyTurrets = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = curEnemies = enemyTurrets.Length;
        progressLength = endCube.position.y - canoe.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<MainMenuController>().ShowPauseMenu();           
        }
        curlenght = (endCube.position.y - canoe.position.y);
        progressSlider.value = 100 - (curlenght/ progressLength) * 100;
        
    }

    public void DisplaySuccessMenu()
    {
        GameObject.FindGameObjectWithTag("TimeCompleted").GetComponent<TextMeshProUGUI>().text =
            "You completed the level in:\n" +
           GameObject.FindGameObjectWithTag("Timer").GetComponent<UITimer>().timerLabel.text;

        float percent = 100 - ((curEnemies / totalEnemies) * 100);
        Debug.Log(percent);
        Debug.Log(curEnemies);
            Debug.Log( totalEnemies);
        GameObject.FindGameObjectWithTag("TurretsDestroyed").GetComponent<TextMeshProUGUI>().text =
            "You destroyed " + string.Format("{0:00}", percent)
      + "% of enemy turrets";
    }
}
