using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRunObstacle : MonoBehaviour
{
    public GameObject[] spikes;

    public float highPosY = 1.0f;
    public float lowPosY = -5.0f;

    public float highWidthPadding = 20.0f;
    public float lowWidthPadding = 10.0f;


    //  ������Ʈ�� Ȱ��ȭ �� �� ��ֹ� ���� �ִ� spike�� ��ġ�� �������� ����
    private void OnEnable()
    {
        for (int i = 0; i < spikes.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                spikes[i].SetActive(true);
            }
            else
            {
                spikes[i].SetActive(false);
            }
        }
    }

    //  ������ ������ ��ġ�� ���� ����
    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        Vector3 placePosition = lastPosition + new Vector3(Random.Range(lowWidthPadding, highWidthPadding), 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
}
