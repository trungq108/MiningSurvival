using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Animator playerAnimator;
    Vector3 target;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }
        UpdateAnimation();
    }
    

    void RayCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1<<0))
        {
            target = hit.point;
        }
        navMeshAgent.SetDestination(target);
    }

    void UpdateAnimation()
    {
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float blendTreeSpeed = localVelocity.z;

        playerAnimator.SetFloat("forwardSpeed", blendTreeSpeed);
    }
}
