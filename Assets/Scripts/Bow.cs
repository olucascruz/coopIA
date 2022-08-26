using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public Transform player;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    private Vector2 direction;

    [SerializeField]
    private Image[] arrows;

    private int qntArrows = 5;

    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity); 
        }
    }

   
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); 
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if(Input.GetMouseButtonDown(0)){
            if(this.qntArrows > 0){
                Shoot();
            }
            UpdateArrows();
            this.qntArrows--;
        }
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPositoin(i * spaceBetweenPoints); 
        }
        ShowArrows();

    }

    public void Shoot(){
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    public Vector2 PointPositoin(float t){
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f  * Physics2D.gravity * (t * t);
        return position;
    }

    public void UpdateArrows(){

        if(this.qntArrows <= 0){
            this.qntArrows = 0;
            ReloadBow();
        }
        if(this.qntArrows > 5){
            this.qntArrows = 5;
        }

    }

    public void ReloadBow(){
        this.qntArrows++;

        if(this.qntArrows < 5){
            Invoke("ReloadBow", 2f);
        }
    }

    public void ShowArrows(){
         switch (this.qntArrows)
       {
        case 0:
            arrows[0].enabled =false;
            arrows[1].enabled =false;
            arrows[2].enabled =false;
            arrows[3].enabled =false;
            arrows[4].enabled =false;

            break;
        case 1:
            arrows[0].enabled =true;
            arrows[1].enabled =false;
            arrows[2].enabled =false;
            arrows[3].enabled =false;
            arrows[4].enabled =false;

            break;
        case 2:
            arrows[0].enabled =true;
            arrows[1].enabled =true;
            arrows[2].enabled =false;
            arrows[3].enabled =false;
            arrows[4].enabled =false;
            break;
        case 3:
            arrows[0].enabled =true;
            arrows[1].enabled =true;
            arrows[2].enabled =true;
            arrows[3].enabled =false;
            arrows[4].enabled =false;
            break;
        case 4:
            arrows[0].enabled =true;
            arrows[1].enabled =true;
            arrows[2].enabled =true;
            arrows[3].enabled =true;
            arrows[4].enabled =false;
            break;
        case 5:
            arrows[0].enabled =true;
            arrows[1].enabled =true;
            arrows[2].enabled =true;
            arrows[3].enabled =true;
            arrows[4].enabled =true;
            break;        
        default:
            arrows[0].enabled =true;
            arrows[1].enabled =true;
            arrows[2].enabled =true;
            arrows[3].enabled =true;
            arrows[4].enabled =true;
            break;        

       }
    }
   
}
