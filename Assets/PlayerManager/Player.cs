using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
         
        }
        if (other.tag == "Enemy")
        {
           // SceneManager.LoadScene("Main");
        }
        if (other.tag == "Ball")
        {
     
            SceneManager.LoadScene("Main");
        }

    }

    
// Start is called before the first frame update
void Start()
    {
        

    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Cube").Length == 0)
        {
            SceneManager.LoadScene("GameClear");
        }
        
    }
    
}


