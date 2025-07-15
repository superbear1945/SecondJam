using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ýű������ڲ������������ܣ���������ʽ��Ϸ����
public class ButtonScript : MonoBehaviour
{
    
    [SerializeField] public ForcePointerScript forcePointerScript;
    //����ForcePointerScript���󣬷������õ�ǰ����ֵ���в���
    private void Start()
    {
        forcePointerScript = GameObject.Find("ForcePointer").GetComponent<ForcePointerScript>();
        if (forcePointerScript == null)
        {
            Debug.LogError("Button:forcePointerScript is missing from ForcePointer component");
        }
    }
    public void AddForce()
    {
        if (forcePointerScript._curForce <= forcePointerScript._maxForce)
        {
            forcePointerScript._curForce += 1;
        }
    }
    public void ReduceForce()
    {
        if (forcePointerScript._curForce>=0)
        {
            forcePointerScript._curForce -= 1;
        }
    }
}
