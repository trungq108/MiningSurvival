using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler: MonoBehaviour
    {
        public static ActionScheduler Instance { set; get; }
        IAction currentAction;

        private void Awake()
        {
            Instance = this;
        }

        public void StartAction(IAction action)
        {
            if(currentAction == action) return;
            if(currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }

}

