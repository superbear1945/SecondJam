using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ForcePointerScript : MonoBehaviour
{
    public Image forcePointerPos;
    public GameObject forceBar;
    //����ֵָ��λ������������������

    public float maxForce;
    public float curForce;
    //�������ֵ����Сֵ����ǰֵ�����������仯����ֵ��Ҫ�ڴ˴��Խ�

    private float lerdSpeed = 20;
    //�������仯����

    // Start is called before the first frame update
    void Start()
    {
        forcePointerPos = GetComponent<Image>();
        forceBar = GetComponent<GameObject>();
        if (forcePointerPos == null)
        {
            Debug.LogError("ForcePointer component is missing from forcePointer component!");
        }
        if(forceBar == null)
        {
            Debug.LogError("ForceBar component is missing from forceBar component!");
        }
        maxForce = 100;
        curForce = 75;
        //��ֵ��ʼ����ʵ��ʹ������Ҫ�Խ������ű���ȡ��ǰ����ֵ
    }

    // Update is called once per frame
    void Update()
    {
        ChangePos();
    }

    void ChangePos()
    {
        forcePointerPos.fillAmount = Mathf.Lerp(a: forcePointerPos.fillAmount, b: curForce / maxForce, t: lerdSpeed * Time.deltaTime);
    }

}
