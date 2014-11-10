using System;
using System.Linq;
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

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
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


        public Vector2 GetNearestAttackableNode(Vector2 from)
        {
            Vector2 offset;
            switch (GetDirectionTo(from))
            {
                case Direction.Right:
                    offset = new Vector2(-20, 0);
                    break;
                case Direction.Up:
                    offset = new Vector2(0, -20);
                    break;
                case Direction.Left:
                    offset = new Vector2(20, 0);
                    break;
                case Direction.Down:
                    offset = new Vector2(0, 20);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var rayOrigin = (Vector2)transform.position + offset;
            var hitInfo = Physics2D.RaycastAll(rayOrigin, -offset).First(a => a.collider.transform.position == transform.position);

            return hitInfo.point;
        }

        public Direction GetDirectionTo(Vector2 from)
        {
            var deltaS = (Vector2)transform.position - from;
            var angle = Mathf.Atan2(deltaS.y, deltaS.x) * Mathf.Rad2Deg;
            if (angle < 0)
                angle += 360;
            if (angle < 45 || angle > 315)
                return Direction.Right;
            else if (angle < 135)
                return Direction.Up;
            else if (angle < 225)
                return Direction.Left;
            else
                return Direction.Down;
        }

        public Vector2 GetDirectionVectorTo(Vector2 from)
        {
            var dir = GetDirectionTo(from);
            switch (dir)
            {
                case Direction.Up:
                    return Vector2.up;
                case Direction.Down:
                    return -Vector2.up;
                case Direction.Left:
                    return -Vector2.right;
                case Direction.Right:
                    return Vector2.right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
