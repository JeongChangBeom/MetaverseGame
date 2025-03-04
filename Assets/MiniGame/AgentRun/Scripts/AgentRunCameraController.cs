using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRunCameraController : MonoBehaviour
{
    public Transform target;
    float offsetX;

    void Start()
    {
        if (target == null)
        {
            return;
        }

        offsetX = transform.position.x - target.position.x;
    }
    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        //  y값은 고정한 채로 x값만 따라가도록 함
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }

}
