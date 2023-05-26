using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
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
        if (other.gameObject.tag == "Floor")
        {

            gameObject.transform.position = new Vector3(7.2f, 10.0f, 64.0f);
            Debug.Log("°¨Áö2");
        }
    }
}
