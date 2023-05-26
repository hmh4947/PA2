using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject CubefloorPrefab;
    public float interval;
    //   public float range=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCube());
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Collider")
        {
            Destroy(gameObject, 0f);
        }

    }
    IEnumerator CreateCube()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while (true)
        {
            // float CubefloorPosX = Random.Range(-range, range);
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
            Instantiate(CubefloorPrefab, transform.position, transform.rotation);
            yield return wait;
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
