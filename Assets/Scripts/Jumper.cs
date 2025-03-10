using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    float jumpPower = 150f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.collider.GetComponent<Rigidbody>();
            Animator playerAnimator = collision.collider.GetComponent<Animator>();

            if (playerRb != null)
            {
                Debug.Log("Jumper 충돌 감지: 점프 실행!"); // 디버그 메시지

                // 기존 Y축 속도를 초기화 (중첩 점프 방지)
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

                // 강한 점프 적용
                playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

                // 점프 애니메이션 적용 (있을 경우)
                if (playerAnimator != null)
                {
                    playerAnimator.SetBool("Jumping", true);
                }
            }
        }
    }

}
