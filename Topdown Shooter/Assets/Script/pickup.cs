using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pickup;
    public AudioClip clip;
    public AudioSource audiosource;
    public playershooting _playerShooterScript;
    public PlayerMovement _playerMovementScript;
    public PlayerPickupText _playerPickupText;
    string ammotext;
    string healtext;
    [SerializeField] private int hpgiven;
    [SerializeField] private int ammogiven;
    [SerializeField] private int overheal;
    [SerializeField] private int speedgiven;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = UnityEngine.Object.FindFirstObjectByType<playershooting>();
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
        _playerPickupText = UnityEngine.Object.FindFirstObjectByType<PlayerPickupText>();
    }
    private void Start()
    {
    }
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerShooterScript.ammo = _playerShooterScript.ammo + ammogiven;
            _playerMovementScript.playerhealth = _playerMovementScript.playerhealth + hpgiven;
            _playerMovementScript.maxhealth = _playerMovementScript.maxhealth + overheal;
            _playerMovementScript.movespeed = _playerMovementScript.movespeed + speedgiven;
            //audiosource.PlayOneShot(clip, 1f);
            if (ammogiven > 0)
            {
                ammotext = ("+" + ammogiven + " AMMO").ToString();
                StartCoroutine(_playerPickupText.PlayerPickup(ammotext));

            }
            if (hpgiven > 0)
            {
                if (_playerMovementScript.maxhealth <= _playerMovementScript.playerhealth)
                {
                    healtext = ("MAX HP");
                }
                else
                {
                    healtext = ("+" + hpgiven + " HP").ToString();
                }
                StartCoroutine(_playerPickupText.PlayerPickup(healtext));

            }
            Destroy(Pickup);


            
        }
      
    }
}
