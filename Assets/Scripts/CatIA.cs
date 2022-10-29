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
    [SerializeField] private Image[] heartCat;
    private bool colliding;
    [SerializeField]
    private Transform startLine;
    [SerializeField]
    private Transform endLine;
    [SerializeField]
    private LayerMask layer;
    private string state = "RUN";

    private bool isIntangible = false;

    private bool isGround = false;

    private LineRenderer lineRenderer;
    [SerializeField] private Transform positionPlayer;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        lineRenderer = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        lineRenderer.SetPosition(0, startLine.position);
        lineRenderer.SetPosition(1, positionPlayer.position);
        colliding = Physics2D.Linecast(startLine.position, endLine.position, layer);
    }

    private void FixedUpdate() {
        
        if(this.state == "RUN"){
            Move();
            if(isGround && colliding){
                Jump();
            }
        }
       
    }


    public void Move(){
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    void Jump()
    {        
        rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        anim.SetBool("jump", true);
        isGround = false;
    }

    void CheckDeath(){
        if(this.catLife < 1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    IEnumerator NotIntangible(){
        yield return new WaitForSeconds(1f);
        isIntangible = false;
        this.state = "RUN";
    }

    void ShowHeart(){
        switch (catLife)
        {
            case 6:
                heartCat[6].enabled = false;
                break;
            case 5:
                heartCat[5].enabled = false;
                break;
            case 4:
                heartCat[4].enabled = false;
                break;
            case 3:
                heartCat[3].enabled = false;
                break;
            case 2:
                heartCat[2].enabled = false;
                break;
            case 1:
                heartCat[1].enabled = false;
                break;
            case 0:
                heartCat[0].enabled = false;
                break;
            default:
                for(int i = 0; i< 6; i++){
                    heartCat[i].enabled = true;
                }
                break;

        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            anim.SetBool("jump", false);

        }
        if(collision.gameObject.tag == "Enemy")
        {
            this.state = "STOPED";
            if(!isIntangible){
                FindObjectOfType<AudioManager>().Play("CatHit");
                this.catLife--;
                CheckDeath();  
                isIntangible = true;
                ShowHeart();
                StartCoroutine(NotIntangible());
        }
            
        }
        
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.layer == 7)
        {
            isGround = true;
        }
    }





}


