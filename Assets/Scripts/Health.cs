using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 20;
        [SerializeField] Animator animator;
        public int currentHealth;
        bool isDying; public bool IsDying { get { return isDying; } }

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage,0);
            if(currentHealth == 0)
            {
                Die();
            }
        }

        void Die()
        {
            if (isDying == true) return;
            animator.SetTrigger("Dead");
            isDying = true;
        }
    }

}
