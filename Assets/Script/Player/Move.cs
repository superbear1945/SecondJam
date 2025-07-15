using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//���������ο������ǽ����������Լ�����дһ���ƶ��߼�
public class Move : MonoBehaviour
{
    PlayerInput _playerInput;
    InputAction _moveAction;
    Vector2 _inputDirection;
    Rigidbody2D _rb2d;

    [Header("�ƶ�����")]
    [SerializeField] float _moveSpeed = 5f;

    void Awake()
    {
        //��ȡPlayerInput���
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
            Debug.LogError("û�ҵ�PlayerInput���");

        //��ȡ�ƶ�����
        _moveAction = _playerInput.actions["Move"];
        if (_moveAction == null)
            Debug.LogError("û�ҵ��ƶ�����");

        //��ȡRigidbody2D���
        _rb2d = GetComponent<Rigidbody2D>();
        if (_rb2d == null)
            Debug.LogError("û�ҵ�Rigidbody2D���");
    }

    void Update()
    {
        _inputDirection = _moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        //_rb2d.MovePosition(_rb2d.position + _inputDirection * _moveSpeed * Time.fixedDeltaTime);
        _rb2d.velocity = _inputDirection * _moveSpeed;
    }
}
