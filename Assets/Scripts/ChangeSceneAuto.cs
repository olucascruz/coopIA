using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneAuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change", 10f);        
    }

    void Change(){
        SceneManager.LoadScene("HomeScene");
    }
    
}
