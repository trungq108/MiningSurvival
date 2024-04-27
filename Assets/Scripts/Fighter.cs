using RPG.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] Mover mover;
        [SerializeField] float range = 5f; public float Range { get { return range; } }
        Transform target;

        private void Update()
        {
            if (target == null) return;
          
            if (target != null && !IsInRange())
            {
                mover.MoveToPoint(target.position);
            }
            else
            {
                mover.PlayerStop();
            }
        }

        bool IsInRange()
        {
            return Vector3.Distance(target.position, transform.position) < range;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void CancelAttack()
        {
            target = null ;
        }
    }
}

