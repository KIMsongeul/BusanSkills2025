using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Follow,
    Attack
}
public class FollowEnemy : MonoBehaviour
{
    public Transform player;
    private float speed = 4f;
    private float detectionRange = 12f;
    private float attackRange = 3f;
    private int damage = 10;
    public EnemyType enemyType;

    private float lastAttackTime = 0;
    private float attackCoolTime = 2f;

    private void Update()
    {
        float distancePlayer = Vector3.Distance(transform.position, player.position);
        if (enemyType == EnemyType.Attack)
        {
            if (distancePlayer <= attackRange)
            {
                if (Time.time - lastAttackTime >= attackCoolTime)
                {
                    HpSystem hp = player.GetComponent<HpSystem>();
                    hp.Damage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
        

        if (distancePlayer <= detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRatation = 
                Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            transform.rotation = 
                Quaternion.Slerp(transform.rotation,lookRatation, Time.deltaTime * 5f);
            transform.position = 
                Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

}
