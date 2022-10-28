using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private string tagCauseDamage;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private bool isIntangible = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }


    void OnCollisionEnter2D(Collision2D collision)
        {
            
            if(collision.gameObject.tag == tagCauseDamage && 
            gameObject.tag != "Cat")
            {
                EffectDamage();
            }
        }
     void OnCollisionStay2D(Collision2D collision)
        {
            
            if(collision.gameObject.tag == tagCauseDamage 
            && gameObject.tag == "Cat")
            { 
                if(!isIntangible){
                    EffectDamage();
                }
            }
        }    

    public void EffectDamage(){

        if(gameObject.tag == "Cat"){
            spriteRenderer.color = new Color(1, 0, 0, 0.8f);
            isIntangible = true;
        }
        else{
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }
        
        StartCoroutine(ReturnNormal());
    }

    IEnumerator ReturnNormal(){
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
        isIntangible = false;
    }



}
