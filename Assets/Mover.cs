using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    Vector3 target;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }
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
}
