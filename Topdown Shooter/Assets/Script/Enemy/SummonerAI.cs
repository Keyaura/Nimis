using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class SummonerAI : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathEffect;
    private GameObject generatedstars;
    private GameObject deathexplosion;
    [SerializeField] private int health = 10;
    public playershooting _playerShooterScript;
    private GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] private int score = 1000;
    public AudioClip deathclip;
    public AudioClip hurtclip;
    public AudioClip attackingclip;
    public Sprite enemyHit;
    public Sprite enemyActive;
    public Sprite enemyDead;
    public enum Spritedata { enemyActive, enemyHit, enemyDead };
    public Spritedata enemySpriteStatus = Spritedata.enemyActive;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = UnityEngine.Object.FindFirstObjectByType<playershooting>();

    }
    void Start()
    {
        StartCoroutine(createstars());
        StartCoroutine(hit());

    }
    IEnumerator createstars()
    {
        for (int i = 0; i < 7; i++)
        {
            if (health > 0)
            {
                generatedstars = Instantiate(projectile, this.transform);
                AudioSource.PlayClipAtPoint(attackingclip, transform.position, 5f);
                yield return new WaitForSeconds(5);
            }
        }
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
                ChangeSprite(Spritedata.enemyHit);
                print(health);
                hit();
            }
            
        }
    }
    private void ChangeSprite(Spritedata spritedata)
    {
        if (spriteRenderer == null) return;
        switch (spritedata)
        {
            case Spritedata.enemyActive:

                break;
            case Spritedata.enemyHit:
                spriteRenderer.sprite = enemyHit;
                

                break;
            case Spritedata.enemyDead:
                spriteRenderer.sprite = enemyDead;
                break;
            default:

                break;
        }

    }
    void LateUpdate()
    {
        if (health >= 0)
        {
            //ChangeSprite(Spritedata.enemyHit);
            
        }
        if (health <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                //generatedstars.health = 0;
                Destroy(generatedstars);
            }

            ChangeSprite(Spritedata.enemyDead);
            deathexplosion = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathexplosion, 0.5f);
            health = health - _playerShooterScript.playerdamage;
            AudioSource.PlayClipAtPoint(deathclip, transform.position, 5f);
            enemy.tag = "enemydead";
            enemy.layer = 13;
            this.enabled = false;


        }
        

    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 60)
        {
            //enemy.transform.position = player.transform.position;
            Debug.Log("hello bitch");
        }
    }
    IEnumerator hit()
    {
        yield return new WaitForSeconds(0.5f);
        ChangeSprite(Spritedata.enemyActive);
    }
}
