using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMonkey : MonoBehaviour
{
    public GameObject deathUI;

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        deathUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
