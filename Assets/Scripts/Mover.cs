using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] Animator playerAnimator;

        private void Update()
        {
            UpdateAnimation();
        }

        public void ToMove(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
        }

        void UpdateAnimation()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float blendTreeSpeed = localVelocity.z;

            playerAnimator.SetFloat("forwardSpeed", blendTreeSpeed);
        }
    }

}