using System;
using UnityEngine;

namespace Assets
{

    public class FillBar : MonoBehaviour
    {
        private RectTransform fillRect;
        void Start()
        {
            fillRect = transform.FindChild("Fill").GetComponent<RectTransform>();
        }

        public void SetFraction(float fraction)
        {
            fillRect.anchorMax = new Vector2(Mathf.Clamp01(fraction), fillRect.anchorMax.y);
        }

    }
}
