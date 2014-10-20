using UnityEngine;

namespace Assets
{
    public class PlayerMouseLooker : MonoBehaviour
    {
        public Texture2D CursorTexture;

        // Use this for initialization
        void Start()
        {
            Cursor.SetCursor(CursorTexture, Vector2.zero, CursorMode.Auto);
        }

        // Update is called once per frame
        void Update()
        {
            var mouseIntersectPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
            var vectorToTarget = mouseIntersectPoint - transform.position;
            Debug.DrawRay(transform.position, vectorToTarget);
            transform.LookAt(transform.position + new Vector3(0, 0, 1), vectorToTarget);
        }
    }
}
