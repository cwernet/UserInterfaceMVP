using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanoeControls : MonoBehaviour
{

    Rigidbody2D rb2d;
    GameObject schemeObject;

    public AudioClip splash;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        schemeObject = GameObject.FindGameObjectWithTag("SchemeGetter");
    }

    // Update is called once per frame
    void Update()
    {

        string curScheme = schemeObject.GetComponent<GetScheme>().GetCurrentScheme();

          
        if (curScheme == "Controller")
        {
            //XBoxOne controller mapping
            //y is up
            if (Input.GetKey(KeyCode.JoystickButton19))
            {
                rb2d.AddForce(Vector2.up * 10 * Time.deltaTime);
            }
            //x is left
            if (Input.GetKey(KeyCode.JoystickButton18))
            {
                rb2d.AddForce(Vector2.left * 10 * Time.deltaTime);
            }
            //b is right
            if (Input.GetKey(KeyCode.JoystickButton17))
            {
                rb2d.AddForce(Vector2.right * 10 * Time.deltaTime);
            }
            //a is down
            if (Input.GetKey(KeyCode.JoystickButton16))
            {
                rb2d.AddForce(Vector2.down * 3 * Time.deltaTime);
            }

        }
        else if( curScheme == "Left")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(Vector2.up * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.AddForce(Vector2.left * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.AddForce(Vector2.right * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.AddForce(Vector2.down * 3 * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (!source.isPlaying)
                {
                    source.PlayOneShot(splash);
                }
                rb2d.AddForce(Vector2.up * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (!source.isPlaying)
                {
                    source.PlayOneShot(splash);
                }
                rb2d.AddForce(Vector2.left * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (!source.isPlaying)
                {
                    source.PlayOneShot(splash);
                }
                rb2d.AddForce(Vector2.right * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (!source.isPlaying)
                {
                    source.PlayOneShot(splash);
                }
                rb2d.AddForce(Vector2.down * 3 * Time.deltaTime);
            }
        }
        
    }
}
