using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public float stopDistance;


    //public float retriveDistance;

    public Transform player;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("StoneSkull").transform;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector2.Distance(enemy.position, player.position) > stopDistance)
            {
                enemy.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(enemy.position, player.position) < stopDistance)
            {
                enemy.position = this.enemy.position;
            }
        }

    }
}
