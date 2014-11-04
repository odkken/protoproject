using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Ability : MonoBehaviour
    {
        public List<StatusEffect> Statuses;

        void Start()
        {
            Debug.Log(name + gameObject.activeSelf + ", " + gameObject.activeInHierarchy);
        }

    }
}
