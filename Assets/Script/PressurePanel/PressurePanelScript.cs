using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurePanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    private UnityEngine.UI.Image pressurePointer;
    public RectTransform rectTransform;

    public float _lerpSpeed = 0.1f; // ��ֵ�ٶ�
    public float _maxPressure = 100;
    public float _curPressure = 75;
    private float _angle;
    void Awake()
    {
        pressurePointer = GetComponent<UnityEngine.UI.Image>();
        if (pressurePointer == null)
        {
            Debug.LogError("δ�ҵ�ѹ��ָ�����������Inspector������pressurePointer");
        }

        rectTransform = GetComponent<RectTransform>();
        if(rectTransform == null)
        {
            Debug.LogError("δ�ҵ�ѹ��ָ��rectTransform���");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PointerRotation();
    }

    void PointerRotation()
    {
        Debug.Log($"��ǰѹ��ֵ: {_curPressure}, ���ѹ��ֵ: {_maxPressure}");
        // ʹ��Mathf.Lerp��ƽ�����ɽǶ�
        if (_maxPressure > 0 && _curPressure > 0 && _curPressure < _maxPressure)
        {
            _angle = Mathf.Lerp(90, -90, _curPressure / _maxPressure);
            Debug.Log($"Angle={_angle}");
        }
        else
        {
            if (_curPressure >= _maxPressure)
            {
                _angle = -90; // �������ֵʱָ��-90��
                _curPressure = _maxPressure; // ȷ��ѹ��ֵ���������
                Debug.Log($"Angle={_angle}��ѹ��ֵ�������ֵ��ָ��ָ��-90��");
            
            }
                
            else if(_curPressure <= 0)
            {
                _angle = 90; // С�ڵ���0ʱָ��90��
                _curPressure = 0; // ȷ��ѹ��ֵ��С��0
                Debug.Log($"Angle={_angle}��ѹ��ֵΪ0������ָ��ָ��90��");
            }
                
        }
        
        //��תѹ����ָ��
        rectTransform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
