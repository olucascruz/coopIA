using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatIA : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public float JumpForce;
    private  int catLife = 7;
    public Text catLifeText;
    private bool colliding;
    [SerializeField]
    private Transform startLine;
    [SerializeField]
    private Transform endLine;
    [SerializeField]
    private LayerMask layer;
    private string state = "RUN";

    private bool isIntangible = false;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    
    void Update()
    {
        
        catLifeText.text = "Vidas: "+ catLife.ToString();
        if(this.catLife < 1){
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        colliding = Physics2D.Linecast(startLine.position, endLine.position, layer);
    }

    private void FixedUpdate() {
        
        if(this.state == "RUN"){
            Move();
            if(colliding){
                Jump();
            }
        }
       
    }


    public void Move(){
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Jump()
    {        
        rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        anim.SetBool("jump", true);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            anim.SetBool("jump", false);

        }
        if(collision.gameObject.tag == "Enemy")
        {
            this.state = "STOPED";
            if(!isIntangible){
                this.catLife--;
                isIntangible = true;
                Invoke("NotIntangible", 1f);
        }
            
        }else{
            this.state = "RUN";
        }
        
    }
    
    void NotIntangible(){
        isIntangible = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.state = "RUN";
        }
    }

}
