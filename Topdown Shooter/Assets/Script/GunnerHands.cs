using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerHands : MonoBehaviour
{
    public Transform tf;
    public float movespeed = 5f;
    public SpriteRenderer enemychar;
    public GameObject enemy;
    public SpriteRenderer weapon;
    public GunnerAI _gunnerAiScript;
    private GameObject player;
    Vector2 playerpos;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _gunnerAiScript = UnityEngine.Object.FindFirstObjectByType<GunnerAI>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()

    {
        if (enemy.CompareTag("enemy")) {
            Vector2 playerpos = player.transform.position;
            tf.Rotate(tf.position * movespeed * Time.fixedDeltaTime);
            Vector2 lookDir = playerpos - (Vector2)tf.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            tf.rotation = Quaternion.Euler(0, 0, angle);
            if (tf.position.x >= player.transform.position.x)
            {

                weapon.flipY = true;
                //firepoint.position = new Vector3(2, 0.25f, 0);
                // print(firepoint.position);
                enemychar.flipX = false;

            }
            else if (tf.position.x <= player.transform.position.x)
            {
                weapon.flipY = false;
                enemychar.flipX = true;
                // firepoint.position = new Vector3(Quaternion.identity, -0.25f, 0);
                //print(firepoint.position);


            }
        }

    }
}
