using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {
        [SerializeField] Health health;

        public bool IsDead() => health.IsDying;
        public void TakeDamage(int damage)
        {
            health.DecreaseHealth(damage);
        }
    }
}
