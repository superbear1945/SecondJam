using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] public ForcePointerScript forcePointerScript;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        forcePointerScript = GameObject.Find("ForcePointer").GetComponent<ForcePointerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //����ģ��
    void GameStart()
    {

    }
    //�л�������ʵ����Ϸ��ʼ���ȴ�������

    public void SetForce(float curForce = 75,float maxForce = 100)
    {
        forcePointerScript._curForce = curForce;
        forcePointerScript._maxForce = maxForce;
    }
    //�����������ֵ����ǰֵ�ĺ���

    void GameQuit()
    {
        Application.Quit();
    }
}
