using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRunBgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    //  게임이 시작될 때 장애물을 배치함
    void Start()
    {
        AgentRunObstacle[] obstacles = GameObject.FindObjectsOfType<AgentRunObstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  지나간 배경을 재배치하여 게임이 지속될 수 있게 함
        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;

            return;
        }

        //  지나간 장애물을 재배치하여 게임이 지속될 수 있게 함
        AgentRunObstacle obstacle = collision.GetComponent<AgentRunObstacle>();

        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition);
        }
    }
}
