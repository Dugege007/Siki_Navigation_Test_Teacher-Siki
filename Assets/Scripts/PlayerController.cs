using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public PlayerController instance;
    private NavMeshAgent agent;
    //public Transform target;

    public float rotateSmoothing = 8;
    public float speed = 5;

    private bool isMoving;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = target.position;

        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.nextPosition = transform.position;
                agent.SetDestination(hit.point);
            }
        }
        Move();
    }

    private void Move()
    {
        if (agent.remainingDistance < 0.5)
        {
            return;
        }
        agent.nextPosition = transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(agent.desiredVelocity), rotateSmoothing * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //HACK 如何解决 surface.BuildNavMesh(); 之后，player会中断移动？
}
