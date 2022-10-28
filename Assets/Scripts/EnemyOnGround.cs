using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnGround : Enemy
{
    private Rigidbody2D rig;   
    public Transform rightCol;
    public Transform leftCol;
    public bool collidingWithWall;
    public bool collidingWithWolf;
    
    public float distance;

    bool isRight = false;

    public Transform groundCheck;

    public LayerMask layer;

    public LayerMask layer2;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
         if(!isRight){
            speed *= -1;
        }

    }
    void Update()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        collidingWithWall = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        collidingWithWolf = Physics2D.Linecast(rightCol.position, leftCol.position, layer2);
        
        if(ground.collider == false || collidingWithWall || collidingWithWolf)
        {
            if(isRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                speed *= -1;
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
                speed *= -1;
            }
        }
    }

    private void FixedUpdate() {
        rig.velocity = new Vector2(speed * Time.deltaTime, rig.velocity.y);   
    }

}
