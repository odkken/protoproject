using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Abilities;
using UnityEngine;

namespace Assets.Scripts.Ai
{
    class AiBattle : MonoBehaviour
    {

        //stuff we need from the gameobject
        private AbilityManager abilityManager;
        private Targeter targeter;


        void Start()
        {
            abilityManager = GetComponent<AbilityManager>();
            targeter = GetComponent<Targeter>();
        }

        void Update()
        {
            if (targeter.CurrentTarget == null)
            {
                var enemyTargets = targeter.PotentialTargets.Where(a => a.TeamType == Targetable.Team.Player).ToList();
                if (enemyTargets.Any())
                    targeter.SetTarget(enemyTargets.First());
            }
        }

    }
}
