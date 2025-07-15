using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineRoomTrigger : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera _virtualCamera;
    int _activePriority = 11; // ���������ʱ�����ȼ�
    int _inactivePriority = 10; // ������Ǽ���ʱ�����ȼ�

    void Awake()
    {
        _virtualCamera = GetComponentInParent<Cinemachine.CinemachineVirtualCamera>();
        if (_virtualCamera == null)
            Debug.LogError("û�ҵ�CinemachineVirtualCamera���");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //��ҽ�������ʱ��������������ȼ�
            _virtualCamera.Priority = _activePriority;
            Debug.Log(collision.name + " �����˴��������򣬼��������");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //����뿪����ʱ��������������ȼ�
            _virtualCamera.Priority = _inactivePriority;
            Debug.Log(collision.name + " �뿪�˴���������ͣ�������");
        }
    }

}
