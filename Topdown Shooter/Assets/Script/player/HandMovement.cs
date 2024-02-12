
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float movespeed = 5f;
    
    Vector2 mousePos;
    Vector2 movement;
    public SpriteRenderer playerchar;
    public SpriteRenderer weapon;
    public Transform firepoint;
    public Camera cam;

    public Transform tf;
    public Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    void FixedUpdate()
    {
        tf.Rotate(tf.position  * movespeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - (Vector2)tf.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        tf.rotation = Quaternion.Euler(0,0, angle);
      if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x >= 0.5)
        {

            weapon.flipY = false;
           //firepoint.position = new Vector3(2, 0.25f, 0);
            // print(firepoint.position);
            playerchar.flipX = true;

        }
        else if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x <= 0.5)
        {
            weapon.flipY =true;
            playerchar.flipX = false;
          // firepoint.position = new Vector3(Quaternion.identity, -0.25f, 0);
            //print(firepoint.position);


        }
      
    }
    void LateUpdate()
    {
        
    }
}

