using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPickupText : MonoBehaviour
{
    public TMP_Text pickuptext;
    public IEnumerator PlayerPickup(string text)
    {
        pickuptext.alpha = 1f;
        pickuptext.SetText(text);
        
        for (int i = 0; i < 20; i++)
        {
            pickuptext.alpha -= 0.05f;
            yield return new WaitForSeconds(0.1f);

        }
        
    }
    
    private void Start()
    {
        pickuptext.alpha = 0f;
       // StartCoroutine(PlayerPickup("+25 AMMO"));
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
