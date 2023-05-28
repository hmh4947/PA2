using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            //SceneManager.LoadScene("Main");
            other.gameObject.transform.position = new Vector3(7.2f, 10.0f, 64.0f);
            Debug.Log("°¨Áö2");

        }
    }
}
