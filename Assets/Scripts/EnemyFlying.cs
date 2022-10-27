using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : Enemy
{
   
    public float distanceDetection;

    private Transform positionPlayer;

    private Vector2 originPosition;

    private bool collidingWithCat = false;

    void Start()
    {
        positionPlayer = GameObject.FindGameObjectWithTag("Cat").transform;
        originPosition = transform.position;
    }

    void Update()
    {
        if(!collidingWithCat){
            Move();
        }
    }

    private void Move(){
        if(positionPlayer.gameObject != null)
        {
            if(Vector2.Distance(transform.position, positionPlayer.position) < distanceDetection)
            {

                transform.position = Vector2.MoveTowards(transform.position,
                                                        positionPlayer.position,
                                                        speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                                                        originPosition,
                                                        speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Cat")
        {
            this.collidingWithCat = true;
        }
        if(collision.gameObject.tag == "Arrow")
        {
           Destroy(gameObject, 0.1f);
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cat")
        {
            this.collidingWithCat = false;
        }
        
    }
}
