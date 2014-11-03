using System.Collections.Generic;

namespace Assets.Scripts
{
    public abstract class Ability
    {
        public List<StatusEffect> Statuses { get; protected set; }

    }
}
