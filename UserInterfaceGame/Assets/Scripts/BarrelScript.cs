using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public Sprite dBSprite;
    public GameObject bullet;
    public GameObject trailPrefab;
    float bulletSpeed = 5;
    public PowerButtons pBScript;
    float targetTime = 1, curTime = 0;
    Sprite initSprite;

    public GameObject muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        initSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = (Mathf.Atan2(dir.y, dir.x))* Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        int TogVal = pBScript.toggleVal;
        curTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            //make muzzle flash!!!
            dir.Normalize();
            Instantiate(muzzleFlash, transform.position + (dir * .75f ) , (Quaternion.AngleAxis(angle, Vector3.forward)));


            Sprite curSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            if (TogVal == 1 || TogVal == 3 || TogVal == 4)
            {
                if (curSprite != initSprite)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = initSprite;
                }
                GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward ));
                GameObject trail = Instantiate(trailPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                trail.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }
            //double bullet
            else if(TogVal == 2 && curTime  > targetTime)
            {
                
                if (curSprite != dBSprite)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = dBSprite;
                }



                    GameObject bulletClone1 = Instantiate(bullet, transform.position - (Vector3.up * .1f), Quaternion.AngleAxis(angle, Vector3.forward));
                    GameObject bulletClone2 = Instantiate(bullet, transform.position + (Vector3.up * .1f), Quaternion.AngleAxis(angle, Vector3.forward));

                    bulletClone1.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                    bulletClone2.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

                    curTime = 0;
                
            }
//            Physics.IgnoreCollision(bulletClone.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("River").GetComponent<Collider>(), true);
        }
    }


}
