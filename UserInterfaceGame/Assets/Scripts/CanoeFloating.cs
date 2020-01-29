using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//finds all nodes on river and pulls player 
public class CanoeFloating : MonoBehaviour
{
    public Image damageHUD;
    private bool damaged = false;
    public Color damageColor;
    public Image healedHUD;
    private bool healed = false;
    public Color healedColor;
    public ParticleSystem smokeSystem;
    public ParticleSystem fireSystem;
    GameObject closestNode;
    int closestNodeIndex;
    GameObject[] riverNodesArray;
    List<GameObject> riverNodes = new List<GameObject>();

    public float hullHealth = 100;
    public Slider healthSlider;

    public GameObject FailureMenu;
    public GameObject SuccessMenu;



    public AudioClip hammer;
    public AudioClip ding;
    public AudioClip Fail;
    public AudioClip hit;
    public AudioClip Success;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    private bool dead = false;


    GetScheme schemeObject;


    // Start is called before the first frame update
    void Start()
    {
        var fireEmission = fireSystem.emission;
        fireEmission.rateOverTime = 0;

        var emission = smokeSystem.emission;
        emission.rateOverTime = 0;

        schemeObject = GameObject.FindGameObjectWithTag("SchemeGetter").GetComponent<GetScheme>();

        riverNodesArray = GameObject.FindGameObjectsWithTag("RiverNode");
        foreach (GameObject node in riverNodesArray)
        {
            riverNodes.Add(node);
        }
        closestNode = riverNodes[0];
        closestNodeIndex = 0;
        //for(int i = 0; i < riverNodes.Length; i ++)
        //{
        //    if (Vector3.Distance(closestNode.transform.position, gameObject.transform.position) >
        //        Vector3.Distance(riverNodes[i].transform.position, gameObject.transform.position))
        //    {
        //        closestNode = riverNodes[i];
        //        closestNodeIndex = i;
        //    }
        //}

        foreach(GameObject node in riverNodes)
        {
            if (Vector3.Distance(closestNode.transform.position, gameObject.transform.position) >
                Vector3.Distance(node.transform.position, gameObject.transform.position))
            {
                closestNode = node;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealFlash();
        DamageFlash();
        Vector3 targetDir = closestNode.transform.position - transform.position;
        targetDir = targetDir.normalized;

        //if (gameObject.transform.position.y < closestNode.transform.position.y - 2f)
        //{
            float dist = Vector3.Distance(closestNode.transform.position, transform.position);
            if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 1)
            {
                // move towards node
                gameObject.GetComponent<Rigidbody2D>().AddForce(targetDir * 3 * Time.deltaTime);
                //gameObject.GetComponent<Rigidbody2D>().MoveRotation(Mathf.Lerp( Vector3.Angle(targetDir, Vector3.right), gameObject.GetComponent<Rigidbody2D>().rotation, 10));
                //gameObject.GetComponent<Rigidbody2D>().MoveRotation(Vector3.Angle(targetDir, Vector3.right));
                Quaternion targetQuat = Quaternion.Euler(new Vector3(0, 0, Vector3.Angle(targetDir, Vector3.right)));
                transform.rotation = Quaternion.Lerp(transform.rotation, targetQuat, Time.deltaTime);
            }

        foreach (GameObject node in riverNodes)
        {
            if (Vector2.Distance(closestNode.transform.position, gameObject.transform.position) >
                Vector2.Distance(node.transform.position, gameObject.transform.position))
            {
                closestNode = node;
            }
        }


        healthSlider.value = hullHealth;



        //deal with smoke particle affect
        if(hullHealth < 85)
        {
            var emission = smokeSystem.emission;
            emission.rateOverTime = 85 - hullHealth;
            if(hullHealth < 50)
            {
                var fireEmission = fireSystem.emission;
                fireEmission.rateOverTime = 50 - hullHealth;
            }

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RiverNode")
        {
            //delete node and add find next closest node
            riverNodes.Remove(closestNode);
            Destroy(closestNode);
            closestNode = riverNodes[0];
        }
        if (collision.gameObject.tag == "EndCube")
        {
            source.PlayOneShot(Success);
            SuccessMenu.SetActive(true);
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<Singleton>().DisplaySuccessMenu();
        }

        if (collision.gameObject.tag == "Repair")
        {
            
            source.PlayOneShot(ding);
            source.PlayOneShot(hammer);
            schemeObject.AddSoundText("Hammering....");

            //find closest repair kit and call a script
            //call repair kit script to move towards top left of screen

            if (hullHealth < 100)
            {
                healed = true;
                hullHealth += 20;
                if(hullHealth > 100)
                {
                    hullHealth = 100;
                }
            }
            Destroy(collision.gameObject);
        }
        //if(collision.gameObject.tag == "EnemyBullet")
        //{
        //    source.PlayOneShot(hit);
        //}
    }

    void HealFlash()
    {
        if (healed)
        {
            healedHUD.color = healedColor;
        }
        else
        {
            healedHUD.color = Color.Lerp(healedHUD.color, Color.clear, 1 * Time.deltaTime);
        }
        healed = false;
    }

    void DamageFlash()
    {
        if(damaged)
        {
            damageHUD.color = damageColor;
        }
        else
        {
            damageHUD.color = Color.Lerp(damageHUD.color, Color.clear, 1 * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage()
    {
        hullHealth -= 2;
        if (hullHealth < 0)
        {
            FailureMenu.SetActive(true);
            if (!dead)
            {
                source.PlayOneShot(Fail);
                dead = true;
            }
            else
                Destroy(this);

            
        }
        damaged = true;
    }
}
