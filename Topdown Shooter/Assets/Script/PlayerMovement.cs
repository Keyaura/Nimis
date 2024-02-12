using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    public Vector2 movement;
    public int playerhealth = 10;
    public int maxhealth = 10;
    public int playerdamage = 3;
    public int enemybulletdamage = 3;
    [SerializeField] private float iframeduration = 3;
    [SerializeField] private float invincibilityDeltaTime;
    private bool invincible;
    public TMP_Text hpui;
    public TMP_Text timer;
    public AudioClip hurtclip;
    public GameObject gameover;
    public SpriteRenderer playersprite;
    public GameObject player;
    public AudioSource audiosource;
    public AudioClip clip;
    public Collider2D collider2D;


    // Update is called once per frame
    //private IEnumerator iframes()
    // {
    // Debug.Log("Player turned invincible!");
    //invincible = true;
    //yield return new WaitForSeconds(iframeduration);
    //for (float i = 0; i < iframeduration; i += invincibilityDeltaTime)
    //{



    //if (playersprite.sortingLayerID == 1)
    //{

    //    playersprite.sortingLayerID = -5;
    //}
    //else
    //{
    //   playersprite.sortingLayerID = 1;
    // }
    //   yield return new WaitForSeconds(invincibilityDeltaTime);
    //}
    //playersprite.sortingLayerID = 1;
    //yield return new WaitForSeconds(invincibilityDeltaTime);

    // invincible = false;
    //   Debug.Log("Player is no longer invincible!");
    // }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (playerhealth >= maxhealth)
        {
            playerhealth = maxhealth;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }



        private void OnCollisionEnter2D(Collision2D collision)
    {
        //audiosource.PlayOneShot(clip, 1.5f);
       
        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetTrigger("Hurt");
            AudioSource.PlayClipAtPoint(hurtclip, transform.position, 5f);
            print(playerhealth);
            //iframes();
        }
    if (collision.gameObject.CompareTag("enemybullet"))
    {
        animator.SetTrigger("Hurt");
        AudioSource.PlayClipAtPoint(hurtclip, transform.position, 5f);
            //iframes();
            playerhealth = playerhealth - enemybulletdamage;
            
    }
    }
        private void FixedUpdate()
    {
        hpui.SetText(playerhealth.ToString());
        movement = movement.normalized;
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        if (playerhealth <= 0)
        {
            Instantiate(gameover, transform.position, transform.rotation);
            Destroy(collider2D);
            this.enabled = false;
        }
    }
  
}
