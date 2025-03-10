using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraChange : MonoBehaviour
{

    public Transform firstPersonView;  // 1��Ī ��ġ
    public Transform thirdPersonView;  // 3��Ī ��ġ
    public Transform player;           // �÷��̾� (ī�޶� �θ�)

    private bool isFirstPerson = true; // ���� 1��Ī���� ����

    private void Start()
    {
        if (firstPersonView == null || thirdPersonView == null || player == null)
        {
            Debug.LogError("CameraChange: �ϳ� �̻��� Transform�� �Ҵ���� �ʾҽ��ϴ�. �ν����Ϳ��� Ȯ���ϼ���!");
            return;
        }

        // �ʱ� ī�޶� ��ġ ����
        transform.position = firstPersonView.position;
        transform.rotation = firstPersonView.rotation;
        transform.SetParent(player); // �÷��̾ ���󰡵��� ����
    }

    public void OnCameraChange(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (firstPersonView == null || thirdPersonView == null || player == null) return;

        if (isFirstPerson)
        {
            // 3��Ī���� ����
            transform.position = thirdPersonView.position;
            transform.rotation = thirdPersonView.rotation;
            transform.SetParent(player); // �÷��̾ ���󰡵��� ����
        }
        else
        {
            // 1��Ī���� ����
            transform.position = firstPersonView.position;
            transform.rotation = firstPersonView.rotation;
            transform.SetParent(player); // �θ� �÷��̾�� �����Ͽ� ���󰡰� ��
        }

        isFirstPerson = !isFirstPerson; // ���� ����
    }
}


