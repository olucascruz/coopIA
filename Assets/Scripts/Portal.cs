using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Cat")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
