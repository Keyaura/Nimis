using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playershooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject playerbulletPrefab;
    public string weaponname;
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
    public TMP_Text gunui;
    public int playerdamage = 3;
    public float spread = 7.5f;
    private float timesincelastshot;
    public float reloadtime = 0.05f;
    public int shotsfired = 0;
    public bool isautomatic;
    public float burstdelay = 0.15f;
    //public bool automatic;
    // public string firebutton;
    //private bool waitingForNextShot;

    private void Start()
    {
        gunui.SetText(weaponname);
    }

    void Update()
    {
        ammoui.SetText($"{ammo}/{totalammo}");

        if (isautomatic ? Input.GetButton("Fire1") : Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(PlayerShoot());
            
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
 
    IEnumerator PlayerShoot()
    {
            if (Time.time > timesincelastshot + reloadtime)
            {
                for (int i = 0; i < shotsfired; i++)
                {
                print("Shot");
                

                if (ammo > 0)
                {
                    float spreadvalue = (Random.Range(-spread, spread)); //randomizes spread before shots
                    Quaternion bulletRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + spreadvalue);
                    //applies random spread to the weapon determined by the spread value
                    GameObject playerbullet = Instantiate(playerbulletPrefab, firePoint.position, bulletRotation);
                    Rigidbody2D rb = playerbullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(playerbullet.transform.right * bulletForce, ForceMode2D.Impulse); //
                    audiosource.PlayOneShot(shootclip, 0.2f);
                    Destroy(playerbullet, 5f); //player bullet timeout, destroys bullets that dont collide with anything
                    timesincelastshot = Time.time;

                    ammo = ammo - 1;
                    //burstActive = false;
                    //StartCoroutine(WaitAfterBurst(burstdelay));
                }
                else if (ammo == 0)
                {
                    audiosource.PlayOneShot(emptyclip, 0.4f);
                    timesincelastshot = Time.time;
                    //plays the "empty ammo thunk" sound effect when the magazine is empty
                   
                }
                yield return new WaitForSeconds(burstdelay);

            }

        }
    }
        void Reload()
    {
        if (totalammo > 0 && ammo != maxheldammo)
        {

            totalammo = totalammo + ammo;
            if (totalammo >= maxheldammo)
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
    private void FixedUpdate()
    {
        gunui.SetText(weaponname);
    }
}