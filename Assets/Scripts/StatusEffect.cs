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
        protected Targetable player;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<Targetable>();
            StartTime = Time.time;
            StartCoroutine(UpdateStatus());
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - StartTime > Duration)
                Expired = true;
        }

        public abstract IEnumerator UpdateStatus();

    }
}
