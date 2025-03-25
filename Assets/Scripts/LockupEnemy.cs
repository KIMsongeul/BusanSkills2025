using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockupEnemy : MonoBehaviour
{
    private float speed = 2f;
    public Transform turnPoint1;
    public Transform turnPoint2;
    private float pointDetectionRange = 1f;

    private bool movingToPoint1 = true; // turnPoint1으로 이동하는지 여부

    private void Start()
    {
        // 시작 시 turnPoint1으로 이동하도록 설정
        transform.position = Vector3.MoveTowards(transform.position, turnPoint1.position, speed * Time.deltaTime);
        movingToPoint1 = true;
    }

    private void Update()
    {
        // 현재 목표 지점
        Transform targetPoint = movingToPoint1 ? turnPoint1 : turnPoint2;

        // 목표 지점과의 거리 계산
        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);

        // 목표 지점에 도달했는지 확인
        if (distanceToTarget <= pointDetectionRange)
        {
            // 목표 지점 변경
            movingToPoint1 = !movingToPoint1;
        }
        else
        {
            // 목표 지점으로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        }
    }
}
