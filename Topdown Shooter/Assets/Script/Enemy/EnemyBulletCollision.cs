using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            //bullet.GetComponent<Renderer>().enabled = false;
            //Destroy(bullet,1f);

        }
    }
}
