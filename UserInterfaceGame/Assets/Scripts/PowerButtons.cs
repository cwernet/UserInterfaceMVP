using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerButtons : MonoBehaviour
{

    public Toggle t1,t2,t3,t4;
    public int toggleVal = 1;
    float  targetTime = 6, curTime = 0;
    bool runtimer = false;
    public SpriteRenderer canoeRenderer;
    Sprite originalCanoe;
    public Sprite sheildCanoe;

    //click sounds
    public AudioClip jingle;
    public AudioClip shuffle;
    public AudioClip unclick;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }


    // Start is called before the first frame update
    void Start()
    {
        t1.isOn = true;
        originalCanoe = canoeRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (runtimer)
        {
            if ((curTime += Time.deltaTime) > targetTime)
            {
                runtimer = false;
                t3.isOn = false;
                canoeRenderer.sprite = originalCanoe;
                curTime = 0;
            }
        }
    }

    public void OnEquip()
    {
        source.PlayOneShot(shuffle);
        if(t3.isOn)
        {
            //start timer
            runtimer = true;
            //set sheild spritre
            canoeRenderer.sprite = sheildCanoe;

        }
        if(t1.isOn)
        {
            toggleVal = 1;
        }
        if (t2.isOn)
        {
            toggleVal = 2;
        }
    }

    public void OnT1Click()
    {

        //if (t2.isOn)
        //{
        //    t2.isOn = false;
        //}
        //if (t3.isOn)
        //{
        //    t3.isOn = false;
        //}
        //if (t4.isOn)
        //{
        //    t4.isOn = false;
        //}
        //if(!t1.isOn)
        //{
        //     t1.isOn = true;
        // }
        // toggleVal = 1;
        if (!t1.isOn)
        {
            source.PlayOneShot(unclick);
        }
        else
        {
            source.PlayOneShot(jingle);
        }
    }
public void OnT2Click()
    {
        //if (!t2.isOn)
        //{
        //   t2.isOn = true;
        //}
        //if (t3.isOn)
        //{
        //    t3.isOn = false;
        //}
        //if (t4.isOn)
        //{
        //    t4.isOn = false;
        //}
        //if (t1.isOn)
        //{
        //    t1.isOn = false;
        //}

        if (!t2.isOn)
        {
            source.PlayOneShot(unclick);
        }
        else
        {
            source.PlayOneShot(jingle);
        }

    }
public void OnT3Click()
    {
        //if (t2.isOn)
        //{
        //    t2.isOn = false;
        //}
        ////if (!t3.isOn)
        ////{
        ////    t3.isOn = true;
        ////}
        //if (t4.isOn)
        //{
        //    t4.isOn = false;
        //}
        //if (t1.isOn)
        //{
        //    t1.isOn = false;
        //}

        if (!t3.isOn)
        {
            source.PlayOneShot(unclick);
        }
        else
        {
            source.PlayOneShot(jingle);
        }


    }
public void OnT4Click()
    {
        // if (t2.isOn)
        // {
        //     t2.isOn = false;
        // }
        // if (t3.isOn)
        // {
        //     t3.isOn = false;
        // }
        // //if (!t4.isOn)
        // //{
        // //    t4.isOn = true;
        //// }
        // if (t1.isOn)
        // {
        //     t1.isOn = false;
        // }
        if (!t4.isOn)
        {
            source.PlayOneShot(unclick);
        }
        else
        {
            source.PlayOneShot(jingle);
        }

    }
}
