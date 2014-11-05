using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class StatusEffect
    {
        public float Duration;
        public float UpdateInterval = 1f;
        public bool IsBeneficial;
        public bool Expired { get { return Time.time - StartTime > Duration; } }

        public float StartTime { get; private set; }
        protected Targetable Player;

        public void BeginEffect(Targetable onPlayer)
        {
            Player = onPlayer;
            StartTime = Time.time;
            onPlayer.StartCoroutine(UpdateStatus());
        }

        public abstract IEnumerator UpdateStatus();

    }
}
