using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HouseIdleWayPoint : MonoBehaviour
{
    public List<Transform> wayPoints; //= new();
    int nextIndex = 0;
    NavMeshAgent agent;

    float damping;
    readonly float patrolSpeed = 3.0f;
    Transform tr;
    bool isPatrol; //순찰유무
    public bool ISPATROL
    {
        get { return isPatrol; }
        set
        {
            isPatrol = value;
            if (isPatrol)
            {
                agent.speed = patrolSpeed;
                damping = 1.0f;
                MoveWayPoint();
            }
        }
    }
    Vector3 traceTarget;
    public Vector3 TRACETARGET
    {
        get { return traceTarget; }
        set
        {
            traceTarget = value;
            TracePlayer(traceTarget);
            damping = 10.0f;
        }
    }
    public float speed
    {
        get { return agent.velocity.magnitude; }
    }
    void Start()
    {
        tr = GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; //목적지에 다다르면 속도를 줄이는 옵션 비활성화
        agent.updateRotation = false; //자동으로 회전하는 기능 비활성화

        var group = GameObject.Find("WayPoint");
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
            nextIndex = Random.Range(0, wayPoints.Count);
        }       
        this.ISPATROL = true;
    }
    public void TracePlayer(Vector3 pos)
    {
        if (agent.isPathStale) return; //이동 경로를 찾지 못하면 다음을 수행하지 말아라
        agent.stoppingDistance = 3;
        agent.destination = pos;
        agent.isStopped = false;
    }
    public void MoveWayPoint() //순찰 목적지점 활성화 함수
    {
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0;
        if (agent.isPathStale) return; //목적지 까지 경로 계산
        agent.destination = wayPoints[nextIndex].position;
        agent.isStopped = false;      
    }

    void Update()
    {
        Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

        if (!isPatrol) return;
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {
            nextIndex = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
        }
    }
}
