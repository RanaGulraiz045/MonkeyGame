using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject myWeapon;
    public GameObject weaponOnGround;
    public GameObject attackButton;
    // Start is called before the first frame update
    void Start()
    {
        myWeapon.SetActive(false);
        attackButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
            attackButton.SetActive(true);
            
            
        }
    }
    
}
