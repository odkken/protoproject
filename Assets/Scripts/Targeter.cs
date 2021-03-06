﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Targeter : MonoBehaviour
    {

        public List<Targetable> PotentialTargets = new List<Targetable>();
        public float TargetCone = .75f;
        public Targetable CurrentTarget;
        private FillBar mainTargetHealth;

        // Use this for initialization

        private void Awake()
        {
            Singleton<TargetManager>.Instance.Register(this);

        }

        private void Start()
        {
            //mainTargetHealth = GameObject.Find("EnemyPortrait").GetComponentInChildren<FillBar>();
        }

        // Update is called once per frame
        private void Update()
        {
            PotentialTargets = PotentialTargets.Where(a => a != null && a.gameObject != null && a.enabled).ToList();
            PotentialTargets.Sort((a, b) => (a.transform.position - transform.position).sqrMagnitude.CompareTo((b.transform.position - transform.position).sqrMagnitude));
            if (Input.GetKeyDown(KeyCode.Tab) && PotentialTargets.Any())
                SwitchTarget();
            //if (CurrentTarget != null)
                //mainTargetHealth.SetFraction(CurrentTarget.GetHealthFraction());
        }

        public void SwitchTarget()
        {
            if (!PotentialTargets.Any()) return;

            if (CurrentTarget == null)
            {
                CurrentTarget = PotentialTargets.First();
                CurrentTarget.Target();
            }
            else
            {
                var targetsInFront = PotentialTargets.Where(a => Vector3.Dot((a.transform.position - transform.position).normalized, transform.up) > TargetCone).ToList();
                if (targetsInFront.Any())
                {
                    Targetable nextTarget;
                    if (!targetsInFront.Contains(CurrentTarget))
                        nextTarget = targetsInFront.First();
                    else
                    {
                        var nextIndex = targetsInFront.IndexOf(CurrentTarget) + 1;
                        if (nextIndex >= targetsInFront.Count)
                        {
                            nextIndex = nextIndex - targetsInFront.Count;
                        }
                        nextTarget = targetsInFront[nextIndex];
                    }
                    CurrentTarget.UnTarget();
                    CurrentTarget = nextTarget;
                    CurrentTarget.Target();
                }
            }
        }

        public void SetTarget(Targetable target)
        {
            var index = PotentialTargets.IndexOf(target);
            if (index >= 0)
            {
                if (CurrentTarget != null)
                {
                    CurrentTarget.UnTarget();
                }
                CurrentTarget = PotentialTargets[index];
                CurrentTarget.Target();
            }
            else
            {
                Debug.Log("Couldn't find target in list!");
            }
        }

        public void OnNewTargetCreated(Targetable targetable)
        {
            if (!PotentialTargets.Contains(targetable))
            {
                PotentialTargets.Add(targetable);
            }
        }


    }
}
