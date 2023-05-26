using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovenment : MonoBehaviour
{
    public float speed;
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Collider")
        {
            Destroy(gameObject, 0f);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime*-1);
    }
}
