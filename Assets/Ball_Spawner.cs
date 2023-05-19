using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateWall());

    }
    IEnumerator CreateWall()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while (true)
        {
            Instantiate(wallPrefab, transform.position, transform.rotation);
            yield return wait;

        }
    }
    // Update is called once per frame

    void Update()
    {
        
    }
}
