using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurePanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEngine.UI.Image pressurePointer;
    public RectTransform rectTransform;

    public float _lerpSpeed = 0.1f; // ��ֵ�ٶ�
    public float _maxPressure;
    public float _curPressure;
    private float _angle;
    void Start()
    {
        if (pressurePointer == null) 
        {
            Debug.LogError("δ�ҵ�ѹ��ָ�����������Inspector������pressurePointer");
        }

        rectTransform = pressurePointer.rectTransform;
        if(rectTransform == null)
        {
            Debug.LogError("δ�ҵ�ѹ��ָ��rectTransform���");
        }

        rectTransform.rotation = Quaternion.Euler(0, 0, 45);
        UIManager._instance.SetPressure();
    }

    // Update is called once per frame
    void Update()
    {
        PointerRotation();
    }

    void PointerRotation()
    {
            
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
                Debug.Log($"Angle={_angle}��ѹ��ֵ�������ֵ��ָ��ָ��-90��");
            
            }
                
            else if(_curPressure <= 0)
            {
                Debug.Log($"Angle={_angle}��ѹ��ֵΪ0������ָ��ָ��90��");

            }
                
        }
        
        rectTransform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
