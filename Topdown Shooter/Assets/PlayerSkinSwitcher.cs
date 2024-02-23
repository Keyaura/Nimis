using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator playeranimator;
    public Animator bskinanimator;
    bool playerchanged;
    public RuntimeAnimatorController playercontroller;
    public RuntimeAnimatorController bskincontroller;

    private void Start()
    {
        playerchanged = false;

    }

    //&& Input.GetKeyDown("q")
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            changecharacter();
        }
        // Update is called once per frame   

        void changecharacter()
        {

            if (playerchanged == false)
            {
                playeranimator.runtimeAnimatorController = bskincontroller;
                bskinanimator.runtimeAnimatorController = playercontroller;
                playerchanged = true;
                print(playerchanged);

            }
            else if (playerchanged == true)
            {
                playeranimator.runtimeAnimatorController = playercontroller;
                bskinanimator.runtimeAnimatorController = bskincontroller;
                playerchanged = false;
                print(playerchanged);
            }
            

        }
    }
}

