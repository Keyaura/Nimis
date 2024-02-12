using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playershooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject playerbulletPrefab;

    public float bulletForce = 20f;
    public int score = 0;
    public int ammo = 15;
    public int maxheldammo = 15;
    public int totalammo = 60;
    public AudioSource audiosource;
    public AudioClip shootclip;
    public AudioClip emptyclip;
    public AudioClip reloadclip;
    public AudioClip yourefuckedclip;
    public TMP_Text ammoui;
    public TMP_Text totalammoui;
    public TMP_Text scoreui;
    public int playerdamage = 3;
    public float spread = 7.5f;
    private float timesincelastshot;
    public float spreadminus = 7.5f;

    private bool waitingForNextShot;


    void Update()
    {
        ammoui.SetText($"{ammo}/{totalammo}");
        if (Input.GetButton("Fire1"))
        {
            PlayerShoot();
        }
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("r"))
        {
            Reload();
            
        }
        if (ammo > maxheldammo)
        {
            AmmoOverflow();
        }
    }

    void AmmoOverflow()
    {
        int overflow = ammo - maxheldammo;
        totalammo = totalammo + overflow;
        ammo = maxheldammo;
    }
    void PlayerShoot()
    {
        if (Time.time > timesincelastshot + 0.15f)
        {


            if (ammo > 0)
            {
                float spreadvalue = (Random.Range(-7.5f, 7.5f));
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + spreadvalue);
                GameObject playerbullet = Instantiate(playerbulletPrefab, firePoint.position, bulletRotation);
                Rigidbody2D rb = playerbullet.GetComponent<Rigidbody2D>();
                rb.AddForce(playerbullet.transform.right * bulletForce, ForceMode2D.Impulse);
                audiosource.PlayOneShot(shootclip, 0.2f);
                Destroy(playerbullet, 5f);
                timesincelastshot = Time.time;

                ammo = ammo - 1;
            }
            else if (ammo == 0)
            {
                audiosource.PlayOneShot(emptyclip, 0.4f);
                timesincelastshot = Time.time;
            }
        }
    }
    void Reload()
    {
        if (totalammo > 0 && ammo != 15)
        {

            totalammo = totalammo + ammo;
            if (totalammo >= 15)
            {
                audiosource.PlayOneShot(reloadclip, 0.5f);
                ammo = maxheldammo;
                totalammo = totalammo - maxheldammo;
            }
            else
            {
                audiosource.PlayOneShot(reloadclip, 0.5f);
                ammo = totalammo;
                totalammo = 0;
            }
        }
        else
        {
            audiosource.PlayOneShot(yourefuckedclip, 1.2f);
        }
    }
}