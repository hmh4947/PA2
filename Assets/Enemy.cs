using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Nav Mesh Agent 사용에 필요
public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
