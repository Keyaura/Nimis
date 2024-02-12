using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialSpawning : MonoBehaviour
{
    [SerializeField] public GameObject spookyenemy;
    [SerializeField] GameObject spookyscaryskull;
    [SerializeField] Collider2D collider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collider);
            Instantiate(spookyenemy,transform.position,Quaternion.identity);

            Destroy(spookyscaryskull);
        }
    }
}
