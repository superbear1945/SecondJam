using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ýű������ڲ������������ܣ���������ʽ��Ϸ����
public class ButtonScript : MonoBehaviour
{
    
    public ForcePointerScript forcePointerScript;
    //����ForcePointerScript���󣬷������õ�ǰ����ֵ���в���
    private void Start()
    {
        forcePointerScript = GetComponent<ForcePointerScript>();
        if (forcePointerScript == null)
        {
            Debug.LogError("forcePointerScript is missing from ForcePointer component");
        }
    }
    public void AddForce()
    {
        if (forcePointerScript.curForce <= forcePointerScript.maxForce)
        {
            forcePointerScript.curForce += 1;
        }
    }
    public void ReduceForce()
    {
        if (forcePointerScript.curForce>=0)
        {
            forcePointerScript.curForce -= 1;
        }
    }
}
