using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : Enemy
{
   
    public float distanceDetection;

    private Transform positionPlayer;

    private Vector2 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        positionPlayer = GameObject.FindGameObjectWithTag("Cat").transform;
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
}
