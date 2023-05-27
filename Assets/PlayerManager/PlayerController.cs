using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource audio; // ���� ����� ���ؼ� AudioSource �ʿ�
    public AudioClip jumpSound;

    Animator animator;
    public CharacterController SelectPlayer; // ������ ĳ���� ��Ʈ�ѷ�
    public float Speed;  // �̵��ӵ�
    public float JumpPow;
    public float rotationSpeed = 360f;
    private float Gravity; // �߷�   
    private Vector3 MoveDir; // ĳ������ �����̴� ����.
    private bool JumpButtonPressed;  //  ���� ���� ��ư ���� ����

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>(); // AudioSource �߰�
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

        SelectPlayer = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        // �⺻��
        Speed = 5.0f;
        Gravity = 15.0f;
        MoveDir = Vector3.zero;
        JumpPow = 7.0f;
        JumpButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectPlayer == null) return;
        // ĳ���Ͱ� �ٴڿ� �پ� �ִ� ��츸 �۵��մϴ�.
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ� �ٴ����� �߶��ϰ� �ִ� ���̹Ƿ�
        // �ٴ� �߶� ���߿��� ���� ��ȯ�� �� �� ���� �����Դϴ�.
        if (SelectPlayer.isGrounded)
        {
            // Ű���忡 ���� X, Z �� �̵������� ���� �����մϴ�.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
                transform.forward,
                MoveDir,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, MoveDir)
                );
                transform.LookAt(transform.position + forward);
                animator.SetBool("isJump 1", false);
            }
            // ������Ʈ�� �ٶ󺸴� �չ������� �̵������� ������ �����մϴ�.
          
            // �ӵ��� ���ؼ� �����մϴ�.
            MoveDir *= Speed;

            // �����̽� ��ư�� ���� ���� : ���� ������ư�� �������� �ʾҴ� ��츸 �۵�
            if (JumpButtonPressed == false && Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJump 1", true);
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
                this.audio.Play();

            }
        }
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ�
        else
        {
            // �߷��� ������ �޾� �Ʒ������� �ϰ��մϴ�.           
            MoveDir.y -= Gravity * Time.deltaTime;
        }

        // ������ư�� �������� ���� ���
        if (!Input.GetButtonDown("Jump"))
        {
            JumpButtonPressed = false;
            // �������� ��ư ���� ���� ����
        }
        // �� �ܰ������ ĳ���Ͱ� �̵��� ���⸸ �����Ͽ�����,
        // ���� ĳ������ �̵��� ���⼭ ����մϴ�.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
        animator.SetFloat("Speed", SelectPlayer.velocity.magnitude);
    }
}
