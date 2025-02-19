using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractiveObjects : MonoBehaviour
{
    GameObject key;
    bool isHit = false;
    float offTime = 0f;

    protected virtual void Awake()
    {
        key = transform.GetChild(0).gameObject;
    }

    protected virtual void Update()
    {
        key.SetActive(isHit);

        if(offTime <= 0)
        {
            OffKey();
        }

        offTime -= Time.deltaTime;
    }

    public virtual void Interactive()
    {

    }

    public void OnKey()
    {
        isHit = true;
        offTime = 0.5f;
    }

    public void OffKey()
    {
        isHit = false;
    }
   
}
