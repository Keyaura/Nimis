using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyCollision;

public class EnemyCollision : MonoBehaviour
{
    public playershooting _playerShooterScript;
    public PlayerMovement _playerMovementScript;

    public GameObject enemy;
    public SpriteRenderer spriteRenderer;
    public Sprite enemyHit;
    public Sprite enemyDead;
    public AudioClip deathclip;
    public AudioClip hurtclip;
    public enum Spritedata {enemyActive,enemyHit,enemyDead};
    public Spritedata enemySpriteStatus = Spritedata.enemyActive;
    [SerializeField] private int health = 5;
    [SerializeField] private int damage = 2;

    // Update is called once per frame
    private GameObject player;
    [SerializeField] private float speed = 1.5f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = Object.FindFirstObjectByType<playershooting>();
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
  
    }
    private void Start()
    {
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(player);
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 1f);
        if (collision.gameObject.CompareTag("Playerbullet"))
        {
            ChangeSprite(Spritedata.enemyHit);
            AudioSource.PlayClipAtPoint(hurtclip, transform.position ,1f);

            health = health - _playerShooterScript.playerdamage;
       }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (health > 0)
            {
                _playerMovementScript.playerhealth = _playerMovementScript.playerhealth - damage;
            }
        }
    }
    void LateUpdate()
    {
        if(health >= 0)
        {
            //ChangeSprite(Spritedata.enemyHit);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(health <= 0)
        {
           
            ChangeSprite(Spritedata.enemyDead);
            health = health - _playerShooterScript.playerdamage;
            enemy.tag = "enemydead";
            enemy.layer = 13;

        }
    }

    private void ChangeSprite(Spritedata spritedata)
    {
        if (spriteRenderer == null) return;
        switch(spritedata)
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
}
