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

        public float AttackableNodeDistanceThreshold = .01f;

        //stuff we need from the gameobject
        private AbilityManager abilityManager;
        private Targeter targeter;
        private Animator animator;



        void Start()
        {
            abilityManager = GetComponent<AbilityManager>();
            targeter = GetComponent<Targeter>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (targeter.CurrentTarget == null)
            {
                var enemyTargets = targeter.PotentialTargets.Where(a => a.TeamType == Targetable.Team.Player).ToList();
                if (enemyTargets.Any())
                    targeter.SetTarget(enemyTargets.First());
            }
            animator.SetBool("Attacking", !NeedsToMove);
        }


        public Vector2 GetNodeDestinationLocation(Targetable target)
        {
            var pointOnTargetColliderBounds = target.GetNearestAttackableNode(transform.position);
            return pointOnTargetColliderBounds + (pointOnTargetColliderBounds - (Vector2)target.transform.position).normalized * ((CircleCollider2D)collider2D).radius;
        }

        public bool NeedsToMove
        {
            get
            {
                if (targeter.CurrentTarget == null)
                    return false;

                return Vector2.Distance(transform.position, GetNodeDestinationLocation(targeter.CurrentTarget)) > AttackableNodeDistanceThreshold;

            }

        }


    }
}
