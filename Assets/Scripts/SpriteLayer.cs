using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteLayer : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            renderer.sortingOrder = -(int)(transform.position.y * 100);
        }
    }
}
