using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDamage : MonoBehaviour
{
    public bool inBonfire;
    public bool stopBurnDamage;

    public Stat maxHealth;

    public void Update()
    {
        if (inBonfire == true)
        {
            if (stopBurnDamage == false)
            {
                stopBurnDamage = true;
                StartCoroutine(FireDamage());
            }
        }
    }

    void OnTriggerEnter(Collider plr)
    {
        if (plr.tag == "fire")
        {
            inBonfire = true;
            //Stat. = false;
        }
    }
    void OnTriggerExit(Collider plr)
    {

        if (plr.tag == "fire")
        {
            StartCoroutine(AfterBurning());
        }
    }
    IEnumerator FireDamage()
    {
        yield return new WaitForSeconds(1);
      //  PlayerHealth.health -= 1;
        stopBurnDamage = false;


    }

    IEnumerator AfterBurning()
    {
        yield return new WaitForSeconds(3);
        inBonfire = false;
        ///PlayerHealth.Treatment = true;

    }
}
