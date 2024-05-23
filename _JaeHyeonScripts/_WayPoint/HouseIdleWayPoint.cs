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
    bool isPatrol; //��������
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
        agent.autoBraking = false; //�������� �ٴٸ��� �ӵ��� ���̴� �ɼ� ��Ȱ��ȭ
        agent.updateRotation = false; //�ڵ����� ȸ���ϴ� ��� ��Ȱ��ȭ

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
        if (agent.isPathStale) return; //�̵� ��θ� ã�� ���ϸ� ������ �������� ���ƶ�
        agent.stoppingDistance = 3;
        agent.destination = pos;
        agent.isStopped = false;
    }
    public void MoveWayPoint() //���� �������� Ȱ��ȭ �Լ�
    {
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0;
        if (agent.isPathStale) return; //������ ���� ��� ���
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
