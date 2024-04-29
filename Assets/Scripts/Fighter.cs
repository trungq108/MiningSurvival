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
        [SerializeField] ActionScheduler actionScheduler;

        [SerializeField] float range = 5f;
        [SerializeField] int damage = 5;
        [SerializeField] float timeBettweenAttack = 1f;

        float timeSinceLastAttack = 0f;
        Health target;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDying) return;
          
            if (target != null && !IsInRange())
            {
                mover.Move(target.transform.position);
            }
            else
            {
                mover.Cancel();
                AttackBehavior();
            }
        }

        bool IsInRange()
        {
            return Vector3.Distance(target.transform.position, transform.position) < range;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.GetComponent<Health>();
            actionScheduler.StartAction(this);
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
            target.TakeDamage(damage);
        }

        public void Cancel()
        {
            animator.SetTrigger("stopAttack");
            target = null ;
        }
    }
}

