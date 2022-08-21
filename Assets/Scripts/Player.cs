using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void FixedUpdate() {
        Move();
    }


    public void Move(){
        float moviment = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moviment * speed, rb.velocity.y);
    }
}
