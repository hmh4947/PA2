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
        // �¿� ����Ű�� ���� ����Ű�� �������� �Ǻ�
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }
        // Move()�� �̿��� �̵�, �浹 ó��, �ӵ� �� ��� ����
        characterController.Move(direction * moveSpeed * Time.deltaTime);
        // Speed �Ķ���͸� ���� ���� �ӵ��� ũ��(Character Controller)�� ����
        animator.SetFloat("Speed", characterController.velocity.magnitude);

        if (GameObject.FindGameObjectsWithTag("Cube").Length == 0)
        {
          //  SceneManager.LoadScene("Main2");

        }
        
    }
}
