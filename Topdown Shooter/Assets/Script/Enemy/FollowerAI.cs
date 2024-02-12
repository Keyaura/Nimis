using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FollowerAI;

public class FollowerAI : MonoBehaviour
{
        public playershooting _playerShooterScript;
    public PlayerMovement _playerMovementScript;
    public GameObject enemy;
    //public Transform tf;
    //public GameObject hitEffect;
    public SpriteRenderer spriteRenderer;
   // public Sprite enemyHit;
    public Sprite inactive;
   // public AudioClip deathclip;
    public AudioClip hurtclip;
    //public enum Spritedata { enemyActive, enemyHit, enemyDead };
    // public Spritedata enemySpriteStatus = Spritedata.enemyActive;
    [SerializeField] private int health = 8;
    [SerializeField] private int damage = 3;

    // Update is called once per frame
    private GameObject player;
    [SerializeField] private float speed = 1.5f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = Object.FindFirstObjectByType<playershooting>();
        _playerMovementScript = Object.FindFirstObjectByType<PlayerMovement>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(player);
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 1f);
        if (collision.gameObject.CompareTag("Playerbullet"))
        {
            AudioSource.PlayClipAtPoint(hurtclip, transform.position, 1f);

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
            if (health >= 0)
            {
                //ChangeSprite(Spritedata.enemyHit);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));

            }
            else if (health < 0)
            {

                //health = health - _playerShooterScript.playerdamage;
                enemy.tag = "enemydead";
                spriteRenderer.sprite = inactive;
                enemy.layer = 11;
                this.enabled = false;
            }
        }
    }
    