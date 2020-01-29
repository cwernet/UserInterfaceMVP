using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerLabel;

    private float time;

    private void Start()
    {
        timerLabel = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
        //var fraction = (time * 100) % 100;

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}