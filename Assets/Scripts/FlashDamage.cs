using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private string tagCauseDamage;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == tagCauseDamage)
            {
                EffectDamage();
            }
        }

    public void EffectDamage(){

        if(gameObject.tag == "Cat"){
            spriteRenderer.color = new Color(1, 0, 0, 0.8f);
        }
        else{
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }
        

        Invoke("ReturnNormal",duration);
    }

    void ReturnNormal(){
        spriteRenderer.color = originalColor;
    }



}
