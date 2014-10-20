using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Life))]
    public class Targeting : MonoBehaviour
    {
        public Life Life { get; private set; }

        // Use this for initialization
        void Start()
        {
            Life = GetComponent<Life>();
        }

        // Update is called once per frame
        void Update()
        {

        }




    }
}
