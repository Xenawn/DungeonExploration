using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraChange : MonoBehaviour
{

    public Transform firstPersonView;  // 1인칭 위치
    public Transform thirdPersonView;  // 3인칭 위치
    public Transform player;           // 플레이어 (카메라 부모)

    private bool isFirstPerson = true; // 현재 1인칭인지 여부

    private void Start()
    {
        if (firstPersonView == null || thirdPersonView == null || player == null)
        {
            Debug.LogError("CameraChange: 하나 이상의 Transform이 할당되지 않았습니다. 인스펙터에서 확인하세요!");
            return;
        }

        // 초기 카메라 위치 설정
        transform.position = firstPersonView.position;
        transform.rotation = firstPersonView.rotation;
        transform.SetParent(player); // 플레이어를 따라가도록 설정
    }

    public void OnCameraChange(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (firstPersonView == null || thirdPersonView == null || player == null) return;

        if (isFirstPerson)
        {
            // 3인칭으로 변경
            transform.position = thirdPersonView.position;
            transform.rotation = thirdPersonView.rotation;
            transform.SetParent(player); // 플레이어를 따라가도록 설정
        }
        else
        {
            // 1인칭으로 변경
            transform.position = firstPersonView.position;
            transform.rotation = firstPersonView.rotation;
            transform.SetParent(player); // 부모를 플레이어로 유지하여 따라가게 함
        }

        isFirstPerson = !isFirstPerson; // 상태 변경
    }
}


