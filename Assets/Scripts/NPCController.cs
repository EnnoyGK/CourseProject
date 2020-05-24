using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour
{
    public List<Transform> wayPoint;
    public int curWayPoint;
    public float moveSpeed;

    Animator anim;
    public float speed;
    NavMeshAgent agent;
    FieldOfView fov;



    // Start is called before the first frame update
    void Start()
    {
        fov = this.gameObject.GetComponent<FieldOfView>();
        anim  = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        fov.FindVisibleTargets();
        if (fov.isVisiblePlayer)
        {
            Chase();
        }
        else
        {
            speed = 3;
            Patrol();
        }
    }

    void Patrol()
    {
        anim.SetBool("Running", false);
        agent.speed = moveSpeed;
        if(wayPoint.Count > 1)
        {
            if(wayPoint.Count > curWayPoint)
            {
                agent.SetDestination(wayPoint[curWayPoint].position);
                float distance = Vector3.Distance(transform.position, wayPoint[curWayPoint].position);

                if(distance > 2.5f)
                {
                    anim.SetFloat("Speed", speed);
                    speed += Time.deltaTime * 3;
                }

                else if(distance <= 2.5f && distance >= 1f)
                {
                    Vector3 direction = (wayPoint[curWayPoint].position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
                }
                else
                {
                    curWayPoint++;
                }
            }
            else if(wayPoint.Count == curWayPoint)
            {
                curWayPoint = 0;
            }
        }

        else if(wayPoint.Count == 1)
        {
            
        }

        else
        {

        }
    }

    void Chase()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dstToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(dstToPlayer <= 2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        anim.SetFloat("Speed", speed);
        speed += Time.deltaTime * 3;
        agent.SetDestination(player.transform.position);
        agent.speed = 8f;
        anim.SetBool("Running", true);
     
    }
}
