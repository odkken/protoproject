using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatusManager : MonoBehaviour
    {
        public List<StatusEffect> ActiveStatusEffects = new List<StatusEffect>();
        // Use this for initialization
        void Start()
        {

        }


        public bool AddStatusEffect(StatusEffect effect)
        {
            if (!ActiveStatusEffects.Select(a => a.GetType()).Contains(effect.GetType()))
            {
                ActiveStatusEffects.Add(effect);
                effect.BeginEffect(GetComponent<Targetable>());
                return true;
            }
            return false;
        }

        // Update is called once per frame
        void Update()
        {
            ActiveStatusEffects.Where(a => a.Expired).ToList().ForEach(a => ActiveStatusEffects.Remove(a));
        }
    }
}
