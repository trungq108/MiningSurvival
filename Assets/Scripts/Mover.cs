using RPG.Combat;
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
        [SerializeField] Fighter fighter;

        private void Update()
        {
            UpdateAnimation();
        }

        public void Move(Vector3 destination)
        {
            fighter.CancelAttack();
            MoveToPoint(destination);
        }

        public void MoveToPoint(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
            navMeshAgent.isStopped = false;
        }

        public void PlayerStop()
        {
            navMeshAgent.isStopped = true;
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