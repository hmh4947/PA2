using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    public static bool stage;
  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {

            gameObject.transform.position = new Vector3(6f, 1.5f, 8f);
            Debug.Log("°¨Áö");
        }
        
    }
}
