using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 3f;
    public float rotateSpeed = 5f;

    NavMeshAgent agent;
    Transform target;

    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                BaseStats targetStats = target.GetComponent<BaseStats>();
                if(targetStats != null)
                {
                    combat.Attack(targetStats);
                }

                FaceTarget();
            }
        }
        else
        {
            if (GetComponent<Enemy>().spawner != null)
            {
                Vector3 spawnerPosition = GetComponent<Enemy>().spawner.transform.position;
                agent.SetDestination(spawnerPosition);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }
}
