using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    void Start()
    {
        if (GameManager._instance != null)
        {
            GameManager._instance.RegisterPlayer(this); //ע�ᵱǰ��ң��������ű��п���ͨ��GameManager��ȡ���
        }
    }
}
