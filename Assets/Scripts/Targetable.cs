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



        public Vector2 GetNearestAttackableNode(Vector2 to)
        {
            var deltaS = to - (Vector2)transform.position;
            var angle = Mathf.Atan2(deltaS.y, deltaS.x) * Mathf.Rad2Deg;
            if (angle < 0)
                angle += 360;
            Vector2 offset;
            if (angle < 45 || angle > 315)
                offset = new Vector2(circleCollider.radius, 0);
            else if (angle < 135)
                offset = new Vector2(0, circleCollider.radius);
            else if (angle < 225)
                offset = new Vector2(-circleCollider.radius, 0);
            else
                offset = new Vector2(0, -circleCollider.radius);
            return (Vector2)transform.position + offset;
        }

        //stuff we need from the gameobject
        public Life Life;
        private StatusManager statusManager;
        private CircleCollider2D circleCollider;

        // Use this for initialization
        void Start()
        {
            Singleton<TargetManager>.Instance.NewTarget(this);
            Life = GetComponent<Life>();
            statusManager = GetComponent<StatusManager>();
            circleCollider = GetComponent<CircleCollider2D>();
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
