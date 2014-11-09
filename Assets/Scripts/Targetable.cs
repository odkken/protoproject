using UnityEngine;

namespace Assets.Scripts
{
    public class Targetable : MonoBehaviour
    {
        public enum Team
        {
            EnemyAi,
            Player,
            Neutral
        }

        public Team TeamType;


        //stuff we need from the gameobject
        public Life Life;
        private StatusManager statusManager;

        // Use this for initialization
        void Start()
        {
            Singleton<TargetManager>.Instance.NewTarget(this);
            Life = GetComponent<Life>();
            statusManager = GetComponent<StatusManager>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void UseAbilityOn(Ability ability)
        {
            foreach (var statusEffect in ability.Statuses)
            {
                if (statusManager.AddStatusEffect(statusEffect))
                    Debug.Log("Added Effect " + statusEffect.GetType().Name);
            }
        }

        public float GetHealthFraction()
        {
            return Life.Health / Life.MaxHealth;
        }

        public void Target()
        {
        }

        public void UnTarget()
        {
        }

        public void OnMouseDown()
        {
            if (enabled)
                FindObjectOfType<PlayerController>().GetComponent<Targeter>().SetTarget(this);
        }

    }
}
