using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public AudioClip hit;
    public AudioClip donk;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    GetScheme schemeGetter;
    bool hitPlayer = false;
    private void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>(), GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("River").GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        schemeGetter = GameObject.FindGameObjectWithTag("SchemeGetter").GetComponent<GetScheme>();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(hitPlayer)
        {
            if (!source.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Canoe")
        {
            if (!GameObject.FindGameObjectWithTag("PowerButtons").GetComponent<PowerButtons>().t3.isOn)
            {
                collision.gameObject.GetComponent<CanoeFloating>().TakeDamage();
                //collision.gameObject.GetComponent<SpriteRenderer>().color = 
                source.PlayOneShot(hit);
                schemeGetter.AddSoundText("Tink!");
                hitPlayer = true;
            }
            else
            {
                source.PlayOneShot(donk);
                schemeGetter.AddSoundText("Donk!");
            }
            hitPlayer = true;

        }
    }
}
