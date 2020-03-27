using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Rigidbody rb;
    private Animator anim;

    public TimelineController timelineController;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        timelineController = FindObjectOfType<TimelineController>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                MoveToPosition(hitInfo.point);
            }
        }

        if (navMesh.hasPath && navMesh.remainingDistance < 0.05f)
        {
            anim.SetBool("moving", false);
        }
        
    }

    private void MoveToPosition(Vector3 position)
    {
        anim.SetBool("moving", true);
        navMesh.SetDestination(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disco"))
        {
            timelineController.Play();
        }
    }
}
