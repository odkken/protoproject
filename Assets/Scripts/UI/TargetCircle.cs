using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TargetCircle : MonoBehaviour
    {
        private RawImage targetCircleImage;
        // Use this for initialization
        void Start()
        {
            targetCircleImage = GameObject.Find("TargetRing").GetComponent<RawImage>();

            var pixels = ((Texture2D) targetCircleImage.texture).GetPixels();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
