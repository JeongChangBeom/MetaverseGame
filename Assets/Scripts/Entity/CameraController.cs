using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraPosition;
    public Vector2 center;
    public Vector2 mapSize;

    public float cameraMoveSpeed;
    private float height;
    private float width;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        //  카메라의 Size는 카메라의 중앙에서 y축 끝지점까지의 거리이다. (세로)
        //  이 값과 화면의 가로 세로 비율을 알면 중앙에서 x축 끝지점까지의 거리도 구할 수 있다. (가로)
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        //  카메라가 부드럽게 플레이어를 따라오도록 함
        transform.position = Vector3.Lerp(transform.position,
                                          playerTransform.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);

        //  카메라가 지정한 맵 밖으로 나가지 않도록 함
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);

    }

    //  맵 사이즈를 정할 때, Scene View에서 직관적으로 확인하기 위해 맵 사이즈를 그리는 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}