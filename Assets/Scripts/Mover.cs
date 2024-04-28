using RPG.Combat;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] Animator playerAnimator;
        [SerializeField] Fighter fighter;
        [SerializeField] ActionScheduler actionScheduler;


        private void Update()
        {
            AnimationUpdate();
        }

        public void StartMoveAction(Vector3 destination)
        {
            actionScheduler.StartAction(this);
            Move(destination);
        }

        public void Move(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        void AnimationUpdate()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float blendTreeSpeed = localVelocity.z;

            playerAnimator.SetFloat("forwardSpeed", blendTreeSpeed);
        }
    }
}