using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DetectLights : MonoBehaviour
{
    Light[] lights;
    public GameObject gb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Yes");
        if (collision.tag == "MainCamera")
        {
            Debug.Log("Yeah");
            gameObject.GetComponent<Light2D>().enabled = true;
            Debug.Log("oh! Yeah");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            gameObject.GetComponent<Light2D>().enabled = false;

        }
    }

}
