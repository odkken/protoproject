using Assets.Scripts.Abilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 5;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var dx = Input.GetAxisRaw("Horizontal");
            var dy = Input.GetAxisRaw("Vertical");
            var newVec = new Vector2(dx, dy).normalized;
            transform.position += new Vector3(newVec.x, newVec.y) * Time.deltaTime * Speed;
            var target = GetComponent<Targeting>().CurrentTarget;
            //if (target != null)
            //    if (Input.GetKeyDown(KeyCode.Alpha1))
            //        target.UseAbilityOn(new Corruption());
        }
    }
}
