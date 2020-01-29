using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject trailPrefab;
    float bulletSpeed = 5, targetTime = 1, curTime = 0;
    public GameObject muzzleFlash;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip shoot;

    // Update is called once per frame
    private void Start()
    {
      source.volume = 0.2f;
    }


    void Update()
    {
        
        if (GetComponent<SpriteRenderer>().isVisible )
        {
            
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            var targpos = GameObject.FindGameObjectWithTag("Canoe").transform.position;
            var dir = Camera.main.WorldToScreenPoint(new Vector3(targpos.x,targpos.y +1, targpos.z)) - pos  ;
            var angle = (Mathf.Atan2(dir.y , dir.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if ((curTime += Time.deltaTime) > targetTime)
            {
                source.PlayOneShot(shoot);
                dir.Normalize();
                Instantiate(muzzleFlash, transform.position + (dir * .5f), (Quaternion.AngleAxis(angle, Vector3.forward)));
                GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                GameObject trail = Instantiate(trailPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                trail.transform.parent = bulletClone.transform;
                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                trail.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                curTime = 0;
            }
        }
    }



    

}
