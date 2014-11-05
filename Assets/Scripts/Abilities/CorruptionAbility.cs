using System.Collections.Generic;
using Assets.Scripts.StatusEffects;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class CorruptionAbility : Ability
    {
        public CorruptionAbility()
        {
            Statuses = new List<StatusEffect>
            {
                new HealthOverTimeStatus
                {
                    Duration = 10f,
                    ScalarHps = -50
                }
            };
        }
    }
}
