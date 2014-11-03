using System.Collections.Generic;
using Assets.Scripts.StatusEffects;

namespace Assets.Scripts.Abilities
{
    public class Corruption : Ability
    {
        // Use this for initialization
        void Start()
        {
            Statuses = new List<StatusEffect>
            {
                new HealthOverTimeStatus()
                {
                    Duration = 10f,
                    ScalarHps = 10f,
                }
            };
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
