using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public int totaldamage;
    private GameObject player;
    public int currentdamage;
    public playershooting _playerShooterScript;
    public TMP_Text CurrentDamageText;
    public TMP_Text TotalDamageText;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = UnityEngine.Object.FindFirstObjectByType<playershooting>();

    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Playerbullet"))
        {
            currentdamage = _playerShooterScript.playerdamage;
            totaldamage = totaldamage + _playerShooterScript.playerdamage;
            CurrentDamageText.SetText(currentdamage.ToString());
            TotalDamageText.SetText(totaldamage.ToString());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentdamage = 0;
            totaldamage = 0;
            CurrentDamageText.SetText(currentdamage.ToString());
            TotalDamageText.SetText(totaldamage.ToString());
        }
    }
    private void FixedUpdate()
    {
        currentdamage = 0;   

    }
}

