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
    private int isMove;
    private int isJump;
    private  int catLife = 7;
    public Text catLifeText;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isMove = Random.Range(0, 5);
        isJump = Random.Range(0, 8);
        catLifeText.text = "Vidas: "+ catLife.ToString();
        if(this.catLife < 1){
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate() {
        if(isMove>0){
            Move();
        }
        if(isJump == 0){
            Jump();
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
            this.catLife--;
        }
        
    }

}
