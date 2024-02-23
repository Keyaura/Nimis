using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAI : MonoBehaviour
{
    public GameObject enemyhands;
    public GameObject enemybulletprefab;
    private GameObject player;
    public GameObject enemy;
    public GameObject firepoint;
    private float randomdelay;
    public Collider2D fireradius;
    public Animator animatortest;
    public AudioClip shootclip;
    [SerializeField] private bool stationary;
    public AudioClip deathclip;
    public playershooting _playerShooterScript;
    
    [SerializeField] public int health = 10;
    public float bulletForce = 0.5f;
    private float timesincelastshot;
    [SerializeField] private float speed = 5f;
    public AudioClip hurtclip; 

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = UnityEngine.Object.FindFirstObjectByType<playershooting>();
        float randomdelay = Random.Range(0.8f, 1.2f);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 1f);
        if (collision.gameObject.CompareTag("Playerbullet"))
        {
            AudioSource.PlayClipAtPoint(hurtclip, transform.position, 1f);
            if (health > 0)
            {
                health = health - _playerShooterScript.playerdamage;
                animatortest.SetTrigger("Hurt");

            }

        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // Distance player

        if (Time.time > timesincelastshot + randomdelay)
        {
            randomdelay = Random.Range(0.8f, 1.2f);
            if (distanceToPlayer < 20)
            {
                float spreadvalue = (Random.Range(-30f, 30f));
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + spreadvalue);
                GameObject enemybullet = Instantiate(enemybulletprefab, firepoint.transform.position, firepoint.transform.rotation);
                //bulletRotation);
                Rigidbody2D rb = enemybullet.GetComponent<Rigidbody2D>();
                rb.AddForce(enemybullet.transform.right * bulletForce, ForceMode2D.Impulse);
                timesincelastshot = Time.time;
                AudioSource.PlayClipAtPoint(shootclip, transform.position, 1f);
                Destroy(enemybullet, 5f);
            }
        }
        if (health > 0)
        {

            if (stationary == false && distanceToPlayer > 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                // animatortest.Set("Running");
                animatortest.SetBool("Running", true);
            }
        }
        if (health <= 0)
        {
            animatortest.SetBool("Running", false);
            animatortest.SetTrigger("Dead");
            enemy.tag = "enemydead";
            enemy.layer = 13;
            AudioSource.PlayClipAtPoint(deathclip, transform.position, 1f);
            this.enabled = false;


        }
    }
}
