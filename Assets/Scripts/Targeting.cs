using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Targeting : MonoBehaviour
    {

        public List<Targetable> potentialTargets = new List<Targetable>();
        public float targetCone = .75f;
        public Targetable currentTarget;

        // Use this for initialization

        void Awake()
        {
            Singleton<TargetManager>.Instance.Register(this);

        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            potentialTargets.Sort((a, b) => (a.transform.position - transform.position).sqrMagnitude.CompareTo((b.transform.position - transform.position).sqrMagnitude));
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (potentialTargets.Any())
                    if (currentTarget == null)
                    {
                        currentTarget = potentialTargets.First();
                        currentTarget.Target();
                    }
                    else
                    {
                        var targetsInFront = potentialTargets.Where(a => Vector3.Dot((a.transform.position - transform.position).normalized, transform.up) > targetCone).ToList();
                        if (targetsInFront.Any())
                        {
                            Targetable nextTarget;
                            if (!targetsInFront.Contains(currentTarget))
                                nextTarget = targetsInFront.First();
                            else
                            {

                                var nextIndex = targetsInFront.IndexOf(currentTarget) + 1;
                                if (nextIndex >= targetsInFront.Count)
                                {
                                    nextIndex = nextIndex - targetsInFront.Count;
                                }
                                nextTarget = targetsInFront[nextIndex];
                            }
                            currentTarget.UnTarget();
                            currentTarget = nextTarget;
                            currentTarget.Target();
                        }
                    }
            }

        }

        public void OnNewTargetCreated(Targetable targetable)
        {
            if (!potentialTargets.Contains(targetable))
            {
                potentialTargets.Add(targetable);
            }
        }



    }
}
