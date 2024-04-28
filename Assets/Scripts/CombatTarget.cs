using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class CombatTarget : MonoBehaviour
    {
       [SerializeField] Health health;

        public void GetAttack(int damage)
        {
            health.TakeDamage(damage);
        }
    }

}
