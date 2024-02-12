using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialAI : MonoBehaviour
{
    private GameObject player;
    public GameObject enemy;
    public Animator animatortest;
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


    }
    private void OnCollisionEnter2D(Collision2D collision)
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


        if (health > 0)
        {

            if (stationary == false)
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
