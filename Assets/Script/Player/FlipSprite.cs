using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    Rigidbody2D _rb2d;

    void Awake()
    {
        // ��ȡ Rigidbody2D ���
        _rb2d = GetComponent<Rigidbody2D>();
        if (_rb2d == null)
            Debug.LogError("δ�ҵ�Rigidbody2D���");
    }

    void FixedUpdate()
    {
        Debug.Log(_rb2d.velocity.x);
        if (_rb2d.velocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (_rb2d.velocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
