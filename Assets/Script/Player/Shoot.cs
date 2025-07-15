using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [Header("˦�˲���")]
    public float castForce = 10f;      // ˦������
    public float shootDelay = 0.5f;//˦�˶����ӳ٣�s��
    public GameObject _bait;//���Ԥ����
    private bool isShooting = false;//�Ƿ�ʼ������

    PlayerInput _playerInput;
    InputAction _shootAction;

    void Awake()
    {
        // ��ȡ PlayerInput ���
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
        {
            Debug.LogError("δ����PlayerInput���");
        }

        //��ȡ˦��Action
        _shootAction = _playerInput.actions["Shoot"];
        if (_shootAction == null)
        {
            Debug.LogError("δ����Shoot Action");
        }

        //��˦���¼�
        _shootAction.performed += StartShoot;
    }

    void OnDisable()
    {
        _shootAction.performed -= StartShoot;
    }

    void StartShoot(InputAction.CallbackContext context)
    {
        if (isShooting) //��ֹ��ͣ˦�˹���
            return;
    
        isShooting = true;
        Debug.Log("��ʼ˦�ˣ�");
        //˦�˶���
        //GetComponent<Animator>().SetTrigger("Cast");
        //�������
        Invoke("SpawnBait", shootDelay);
    }

    void SpawnBait()
    {
        if (_bait != null)
        {
            //�������
            Vector2 spawnPos = transform.position + transform.right * 1f;//���ɫ���ұ�˦��
            // ʵ�������
            GameObject baitInstance = Instantiate(_bait, spawnPos, Quaternion.identity);
             // ��� 2D ������
            Rigidbody2D baitRb = baitInstance.GetComponent<Rigidbody2D>();
            if (baitRb != null)
            {
                baitRb.AddForce(Vector2.right * castForce, ForceMode2D.Impulse); // ����ʩ��
            }
        }
        isShooting = false; //����˦��״̬
    }
}
