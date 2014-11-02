using UnityEngine;

namespace Assets.Scripts
{
    public abstract class StatusEffect : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UpdateStatus();
        }

        public abstract void UpdateStatus();

    }
}
