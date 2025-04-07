using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Transform player;

    public float attackTimer = 5f;
    public float attackTiming = 0f;
    public bool isAttack;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;

    }

    private void Update()
    {
        if (isAttack)
        {
            attackTiming += Time.deltaTime;
            if(attackTiming > attackTimer)
            {
                isAttack = false;
                attackTiming = 0f;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, player.position) < 0.4f)
            {
                if (!isAttack)
                {
                    isAttack = true;
                    player.GetComponent<PlayerCtrl>().SetDamage(5);
                }
            }
        }
    }

}
