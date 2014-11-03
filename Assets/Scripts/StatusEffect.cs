using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class StatusEffect : MonoBehaviour
    {
        public float Duration;
        public float UpdateInterval = 1f;
        public bool IsBeneficial;
        public bool Expired { get; private set; }

        public float StartTime { get; private set; }
        protected Targetable Player;

        // Use this for initialization
        void Start()
        {
        }

        public void BeginEffect(Targetable onPlayer)
        {
            Player = onPlayer;
            StartTime = Time.time;
            StartCoroutine(UpdateStatus());
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - StartTime > Duration)
                Expired = true;
            if (Expired)
                Destroy(gameObject);
        }

        public abstract IEnumerator UpdateStatus();

    }
}
