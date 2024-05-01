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
        CombatTarget target;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead()) return;
          
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

        public bool CanAtttack(CombatTarget combatTarget)
        {
            if(combatTarget == null) return false;
            return combatTarget != null && !combatTarget.IsDead(); // this return true
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget;
            actionScheduler.StartAction(this);
        }

        void AttackBehavior()
        {
            if(!CanAtttack(target)) return; 

            transform.LookAt(target.transform.position);
            if(timeSinceLastAttack > timeBettweenAttack)
            {
                animator.ResetTrigger("stopAttack");
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
            animator.ResetTrigger("Attack");
            animator.SetTrigger("stopAttack");
            target = null ;
        }
    }
}

