using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TargetManager : MonoBehaviour
    {
        private readonly List<Targeting> targetingListeners = new List<Targeting>();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void NewTarget(Targetable target)
        {
            foreach (var targetingListener in targetingListeners)
            {
                targetingListener.OnNewTargetCreated(target);
            }
        }

        public void Register(Targeting listener)
        {
            if (!targetingListeners.Contains(listener))
            {
                targetingListeners.Add(listener);
            }
        }

    }
}
