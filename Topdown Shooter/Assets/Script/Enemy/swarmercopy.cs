using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarmercopy : MonoBehaviour
{
    public GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(piss());

    }
    IEnumerator piss()
    {

            for (int j = 0; j < 5; j++)
            {
                Instantiate(clone, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
