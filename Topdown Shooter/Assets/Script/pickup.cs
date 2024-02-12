using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pickup;
    public GameObject player;
    public AudioClip clip;
    public playershooting _playerShooterScript;
    public PlayerMovement _playerMovementScript;
    [SerializeField] private int hpgiven;
    [SerializeField] private int ammogiven;
    [SerializeField] private int overheal;
    [SerializeField] private int speedgiven;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        _playerShooterScript = UnityEngine.Object.FindFirstObjectByType<playershooting>();
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerShooterScript.ammo = _playerShooterScript.ammo + ammogiven;
            _playerMovementScript.playerhealth = _playerMovementScript.playerhealth + hpgiven;
            _playerMovementScript.maxhealth = _playerMovementScript.maxhealth + overheal;
            _playerMovementScript.movespeed = _playerMovementScript.movespeed + speedgiven; 
            AudioSource.PlayClipAtPoint(clip, transform.position, 10f);
            Destroy(Pickup);

        }
    }
}
