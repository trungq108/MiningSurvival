using RPG.Control;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] Mover mover;
        [SerializeField] Animator animator;
        [SerializeField] float range = 5f;
        [SerializeField] float timeBettweenAttack = 1f;
        float timeSinceLastAttack = 0f;
        Transform target;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
          
            if (target != null && !IsInRange())
            {
                mover.Move(target.position);
            }
            else
            {
                mover.Cancel();
                AttackBehavior();
            }
        }

        bool IsInRange()
        {
            return Vector3.Distance(target.position, transform.position) < range;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            ActionScheduler.Instance.StartAction(this);
        }

        void AttackBehavior()
        {
            if(timeSinceLastAttack > timeBettweenAttack)
            {
                animator.SetTrigger("Attack");
                timeSinceLastAttack = 0f;
                Hit();
            }
        }

        void Hit()
        {
            target.GetComponent<Health>().TakeDamage(5);
        }

        public void Cancel()
        {
            target = null ;
        }
    }
}

