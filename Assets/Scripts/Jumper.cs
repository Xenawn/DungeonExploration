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
                Debug.Log("Jumper �浹 ����: ���� ����!"); // ����� �޽���

                // ���� Y�� �ӵ��� �ʱ�ȭ (��ø ���� ����)
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

                // ���� ���� ����
                playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

                // ���� �ִϸ��̼� ���� (���� ���)
                if (playerAnimator != null)
                {
                    playerAnimator.SetBool("Jumping", true);
                }
            }
        }
    }

}
