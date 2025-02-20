using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class BaseInteractiveObjects : MonoBehaviour
{
    //  key = 상호작용할 때 눌러야하는 키
    private GameObject key;

    private bool isHit = false;
    private float offTime = 0f;

    protected virtual void Awake()
    {
        key = transform.GetChild(0).gameObject;
    }

    //  충돌될 때 key를 보여주고, 충돌된지 offTime만큼 지나면 key를 안보여줌
    protected virtual void Update()
    {
        key.SetActive(isHit);

        if(offTime <= 0)
        {
            OffKey();
        }

        offTime -= Time.deltaTime;
    }

    //  상호작용 가능한 객체와 상호작용 시 호출되는 함수
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
