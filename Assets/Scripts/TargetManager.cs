using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TargetManager : MonoBehaviour
    {
        private readonly List<Targeter> targetingListeners = new List<Targeter>();
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

        public void Register(Targeter listener)
        {
            if (!targetingListeners.Contains(listener))
            {
                targetingListeners.Add(listener);
            }
        }

    }
}
