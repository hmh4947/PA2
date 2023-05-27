using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource audio; // 사운드 출력을 위해선 AudioSource 필요
    public AudioClip jumpSound;

    Animator animator;
    public CharacterController SelectPlayer; // 제어할 캐릭터 컨트롤러
    public float Speed;  // 이동속도
    public float JumpPow;
    public float rotationSpeed = 360f;
    private float Gravity; // 중력   
    private Vector3 MoveDir; // 캐릭터의 움직이는 방향.
    private bool JumpButtonPressed;  //  최종 점프 버튼 눌림 상태

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>(); // AudioSource 추가
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

        SelectPlayer = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        // 기본값
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
        // 캐릭터가 바닥에 붙어 있는 경우만 작동합니다.
        // 캐릭터가 바닥에 붙어 있지 않다면 바닥으로 추락하고 있는 중이므로
        // 바닥 추락 도중에는 방향 전환을 할 수 없기 때문입니다.
        if (SelectPlayer.isGrounded)
        {
            // 키보드에 따른 X, Z 축 이동방향을 새로 결정합니다.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
                transform.forward,
                MoveDir,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, MoveDir)
                );
                transform.LookAt(transform.position + forward);
                animator.SetBool("isJump 1", false);
            }
            // 오브젝트가 바라보는 앞방향으로 이동방향을 돌려서 조정합니다.
          
            // 속도를 곱해서 적용합니다.
            MoveDir *= Speed;

            // 스페이스 버튼에 따른 점프 : 최종 점프버튼이 눌려있지 않았던 경우만 작동
            if (JumpButtonPressed == false && Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJump 1", true);
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
                this.audio.Play();

            }
        }
        // 캐릭터가 바닥에 붙어 있지 않다면
        else
        {
            // 중력의 영향을 받아 아래쪽으로 하강합니다.           
            MoveDir.y -= Gravity * Time.deltaTime;
        }

        // 점프버튼이 눌려지지 않은 경우
        if (!Input.GetButtonDown("Jump"))
        {
            JumpButtonPressed = false;
            // 최종점프 버튼 눌림 상태 해제
        }
        // 앞 단계까지는 캐릭터가 이동할 방향만 결정하였으며,
        // 실제 캐릭터의 이동은 여기서 담당합니다.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
        animator.SetFloat("Speed", SelectPlayer.velocity.magnitude);
    }
}
