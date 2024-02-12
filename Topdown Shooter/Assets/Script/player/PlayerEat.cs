using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
    public Collider2D biteradius;
    public AudioClip biteclip;
    public Animator animator;
    public Object randompickup;
    public GameObject medkitsmall;
    public GameObject medkitmedium;
    public GameObject medkitlarge;
    public PlayerMovement _playerMovementScript;
    public GameObject ammoboxsmall;
    public GameObject ammoboxmedium;
    public GameObject ammoboxlarge;
    public int legitkills = 0;
    //public static Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);

    // Start is called before the first frame update
    //public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity)
    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }

    private void ConsumeDead()
    {
    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("enemydead")) 
            {
                // collider.transform
                PickupGeneration(collider.transform.position);
                legitkills++;
                
                Destroy(collider.gameObject);
                //animator.SetTrigger("Eating");

            }
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("e"))
        {
            ConsumeDead();
            animator.SetTrigger("Eating");
            AudioSource.PlayClipAtPoint(biteclip, transform.position, 1f);
            animator.SetTrigger("Eating");

            //GameObject[] gos = GameObject.FindGameObjectsWithTag("enemydead");
            //foreach (GameObject go in gos)
            //    Destroy(go);
        }
    }
    void PickupGeneration(Vector3 position)
    {
        int willdroppickups = Random.Range(1, 5);
        print(willdroppickups);
        if (willdroppickups == 3)
        {
            int pickupgenerated = Random.Range(1, 21);
            if (_playerMovementScript.maxhealth == _playerMovementScript.playerhealth)
            {
                switch (pickupgenerated)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        Instantiate(ammoboxsmall, position, Quaternion.identity);
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                        Instantiate(ammoboxmedium, position, Quaternion.identity);
                        break;
                    case 19:
                        Instantiate(medkitlarge, position, Quaternion.identity);
                        break;
                    case 20:
                        Instantiate(ammoboxlarge, position, Quaternion.identity);
                        break;
                }
            }
            else
            {
                switch (pickupgenerated)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        Instantiate(ammoboxsmall, position, Quaternion.identity);
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        Instantiate(medkitsmall, position, Quaternion.identity);
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        Instantiate(medkitmedium, position, Quaternion.identity);
                        break;
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                        Instantiate(ammoboxmedium, position, Quaternion.identity);
                        break;
                    case 19:
                        Instantiate(medkitlarge, position, Quaternion.identity);
                        break;
                    case 20:
                        Instantiate(ammoboxlarge, position, Quaternion.identity);
                        break;
                }
            }

        }
    }

}
