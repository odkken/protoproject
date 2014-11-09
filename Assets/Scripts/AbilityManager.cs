using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets
{
    public class AbilityManager : MonoBehaviour
    {
        public List<Ability> Abilities;

        void Start()
        {
            Abilities = new List<Ability>();
        }

        void Update()
        {

        }


        public List<Ability> GetAbilities()
        {
            return Abilities;
        }

        public void UseAbility(int index, Targetable target)
        {
            if (index < Abilities.Count && target != null)
                target.UseAbilityOn(Abilities[index]);
        }
    }
}
