using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnGround : Enemy
{
    private Rigidbody2D rig;   
    public Transform rightCol;
    public Transform leftCol;
    public bool colliding;
    
    public float distance;

    bool isRight = false;

    public Transform groundCheck;

    public LayerMask layer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
        
        if(ground.collider == false || colliding)
        {
            if(isRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
            }
        }
    }

}
