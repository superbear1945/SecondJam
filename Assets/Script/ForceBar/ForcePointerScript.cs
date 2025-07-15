using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ForcePointerScript : MonoBehaviour
{
    public Image forcePointerPos;
    //����ֵָ��λ��

    public float _maxForce;
    public float _curForce;
    //�������ֵ����ǰֵ

    private float _lerdSpeed = 20;
    //�������仯����

    UIManager _manager;
    //����UIManager�ű�����ȡ����ֵ

    // Start is called before the first frame update
    void Start()
    {
        forcePointerPos = GetComponent<Image>();
        if (forcePointerPos == null)
        {
            Debug.LogError("ForcePointer component is missing from forcePointer component!");
        }
        //��ʼ������ָʾ��λ��

        _manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_manager == null)
        {
            Debug.LogError("UIManager is missing from the scene!");
        }
        _manager.SetForce(75, 100);//����SetForce���������ó�ʼ����ֵ�����ֵ
    }

    // Update is called once per frame
    void Update()
    {
        
        ChangePos();
    }

    void ChangePos()
    {
        forcePointerPos.fillAmount = Mathf.Lerp(a: forcePointerPos.fillAmount, b: _curForce / _maxForce, t: _lerdSpeed * Time.deltaTime);
    }

}
