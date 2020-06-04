using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private float timeBtwShoots;
    public float startTimeBtwShots;
    public GameObject FirePoint;

    public GameObject projectile;
    private Transform firePointPosition;
    // Start is called before the first frame update
    void Start()
    {
        firePointPosition = FirePoint.transform;
        timeBtwShoots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, firePointPosition.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }

    }
}
