using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    

    public AudioClip shoot;
    public AudioClip explode;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    GetScheme schemeGetter;

    public GameObject explosion;

    private void Start()
    {
        schemeGetter = GameObject.FindGameObjectWithTag("SchemeGetter").GetComponent<GetScheme>();

        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Canoe").GetComponent<BoxCollider2D>(), GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("River").GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        //if (GetComponent<Collider2D>())
        //{
        //    Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("River").GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        //    Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Canoe").GetComponent<BoxCollider2D>(), GetComponent<Collider2D>(), true);
        //}
        source.PlayOneShot(shoot);
        schemeGetter.AddSoundText("Pow!");


    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("ScreenShaker").GetComponent<ScreenShaker>().TriggerShake();

            GameObject exploder = Instantiate(explosion); 
            exploder.transform.position = collision.gameObject.transform.position;
            schemeGetter.AddSoundText("Explosion!");
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<Singleton>().curEnemies -=1;


            Destroy(collision.gameObject);

            source.PlayOneShot(explode);
            //GetComponent<SpriteRenderer>().sortingLayerID = 1;
            //Destroy(gameObject);
        }
    }
}
