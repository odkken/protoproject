using System.Collections.Generic;
using Assets.Scripts.StatusEffects;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class Corruption : Ability
    {
        public Corruption()
        {
            Statuses = new List<StatusEffect>
            {
                (StatusEffect)Object.Instantiate(Resources.Load<HealthOverTimeStatus>("Prefabs/StatusEffects/CorruptionEffect"),Vector3.zero, Quaternion.identity)
            };
        }
    }
}
