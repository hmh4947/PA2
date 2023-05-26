using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{

    private bool cube3;
    public GameObject Target;

    void Start()
    {
      
       cube3 = false;
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            
            Target.SetActive(true);
            cube3 = true;
            Debug.Log("»ý±è");
        }
         else
          {
            Target.SetActive(false);
              cube3 = false;
          
         }
    }
   
}