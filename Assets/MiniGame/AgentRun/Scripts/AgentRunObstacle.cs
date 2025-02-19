using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRunObstacle : MonoBehaviour
{
    public GameObject[] spikes;
    private bool stepped = false;

    public float highPosY = 1.0f;
    public float lowPosY = -5.0f;

    public float highWidthPadding = 20.0f;
    public float lowWidthPadding = 10.0f;

    private void OnEnable()
    {
        stepped = false;

        int spikesCount = 0;

        for (int i = 0; i < spikes.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                if (spikesCount < spikes.Length - 1)
                {
                    spikes[i].SetActive(true);
                }
            }
            else
            {
                spikes[i].SetActive(false);
            }
        }
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        Vector3 placePosition = lastPosition + new Vector3(Random.Range(lowWidthPadding, highWidthPadding), 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            //  게임 종료;
        }
    }

}
