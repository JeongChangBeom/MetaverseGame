using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class BaseInteractiveObjects : MonoBehaviour
{
    //  key = ��ȣ�ۿ��� �� �������ϴ� Ű
    private GameObject key;

    private bool isHit = false;
    private float offTime = 0f;

    protected virtual void Awake()
    {
        key = transform.GetChild(0).gameObject;
    }

    //  �浹�� �� key�� �����ְ�, �浹���� offTime��ŭ ������ key�� �Ⱥ�����
    protected virtual void Update()
    {
        key.SetActive(isHit);

        if(offTime <= 0)
        {
            OffKey();
        }

        offTime -= Time.deltaTime;
    }

    //  ��ȣ�ۿ� ������ ��ü�� ��ȣ�ۿ� �� ȣ��Ǵ� �Լ�
    public virtual void Interactive()
    {

    }

    public void OnKey()
    {
        isHit = true;
        offTime = 0.5f;
    }

    public virtual void OffKey()
    {
        isHit = false;
        offTime = 99999999f;
    }
   
}
