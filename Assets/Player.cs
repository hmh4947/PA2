using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;

    CharacterController characterController;
    Animator animator;

    
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
            SceneManager.LoadScene("GameOver");
        }

    }
   
// Start is called before the first frame update
void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        // 좌우 방향키와 상하 방향키를 눌렀는지 판별
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }
        // Move()를 이용해 이동, 충돌 처리, 속도 값 얻기 가능
        characterController.Move(direction * moveSpeed * Time.deltaTime);
        // Speed 파라미터를 통해 현재 속도의 크기(Character Controller)를 전달
        animator.SetFloat("Speed", characterController.velocity.magnitude);

        if (GameObject.FindGameObjectsWithTag("Cube").Length == 0)
        {
          //  SceneManager.LoadScene("Main2");

        }
        
    }
}
