using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatusManager : MonoBehaviour
    {
        private List<StatusEffect> activeStatusEffects = new List<StatusEffect>();
        // Use this for initialization
        void Start()
        {

        }


        public bool AddStatusEffect(StatusEffect effect)
        {
            if (!activeStatusEffects.Select(a => a.GetType()).Contains(effect.GetType()))
            {
                activeStatusEffects.Add(effect);
                effect.BeginEffect(GetComponent<Targetable>());
                return true;
            }
            return false;
        }

        // Update is called once per frame
        void Update()
        {
            activeStatusEffects.Where(a => a.Expired).ToList().ForEach(a => activeStatusEffects.Remove(a));
        }
    }
}
