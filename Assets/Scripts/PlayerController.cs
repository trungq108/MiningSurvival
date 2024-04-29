using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using RPG.Control;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movement
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Mover mover;
        [SerializeField] Fighter fighter;
        RaycastHit[] results = new RaycastHit[3];

        private void Update()
        {
            if(RayCheckToCombat()) return; 
            RayCheckToMove();
        }

        void RayCheckToMove()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(GetMouseRay(), out RaycastHit hit, Mathf.Infinity))
                {
                    mover.StartMoveAction(hit.point);
                }
            }
        }

        bool RayCheckToCombat()
        {
            int sizeRay = Physics.RaycastNonAlloc(GetMouseRay(), results);
            for(int i = 0; i < sizeRay; i++)
            {
                CombatTarget combatTarget = results[i].transform.GetComponent<CombatTarget>();
                if (combatTarget==null) continue;

                if(Input.GetMouseButtonDown(0))
                {
                    fighter.Attack(combatTarget);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }

}