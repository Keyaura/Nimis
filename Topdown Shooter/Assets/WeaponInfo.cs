using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public string weaponname;
    public float bulletforce;
    public int ammo;
    public int maxheldammo;
    public int playerdamage;
    public float spread;
    public int shotsfired;
    public float reloadtime;
    public bool isautomatic;
    public float burstdelay;
    public GameObject ammoused;
    public Sprite weaponpickupsprite;
    public SpriteRenderer heldweapon;
    public AudioClip shootclip;
    public AudioClip emptyclip;
    public AudioClip reloadclip;
    public playershooting _playerShooterScript;
    public PlayerPickupText _playerPickupText;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerShooterScript = UnityEngine.Object.FindFirstObjectByType<playershooting>();
        _playerPickupText = UnityEngine.Object.FindFirstObjectByType<PlayerPickupText>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey("q"))
        {
            StartCoroutine(_playerPickupText.PlayerPickup(weaponname));
            

            heldweapon.sprite = weaponpickupsprite;
            _playerShooterScript.playerbulletPrefab = ammoused;
            _playerShooterScript.weaponname = weaponname;
            _playerShooterScript.ammo = ammo;
            _playerShooterScript.maxheldammo = maxheldammo;
            _playerShooterScript.spread = spread;
            _playerShooterScript.shotsfired = shotsfired;
            _playerShooterScript.reloadtime = reloadtime;
            _playerShooterScript.isautomatic = isautomatic;
            _playerShooterScript.playerdamage = playerdamage;
            _playerShooterScript.bulletForce = bulletforce;
            _playerShooterScript.burstdelay = burstdelay;
            
        }
    }
}
