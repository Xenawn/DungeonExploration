using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput; // ���� �Է� ��

    public float jumpPower;
    public LayerMask groundLayerMask;


    private Rigidbody rigidbody;
    private Animator animatior;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animatior = GetComponent<Animator>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        if (IsGrounded())
        {
            animatior.SetBool("Jumping", false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
           animatior.SetBool("Moving", true);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
           animatior.SetBool("Moving", false);
        }
    }
    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;  // ���� y �ӵ��� ����
        rigidbody.velocity = dir;


    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            animatior.SetBool("Jumping", true);
        }
        
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        // 4���� Ray �� groundLayerMask�� �ش��ϴ� ������Ʈ�� �浹�ߴ��� ��ȸ�Ѵ�.
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }
}
