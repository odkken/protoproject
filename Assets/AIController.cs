using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Abilities;
using UnityEngine;

namespace Assets
{
    public class AIController : MonoBehaviour
    {
        public float Speed = 1;
        public float DirChangeInterval = 1;
        private Animator animator;
        private int currentDirection;
        private AbilityManager abilityManager;
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            abilityManager = GetComponent<AbilityManager>();
            abilityManager.Abilities = new List<Ability> { new CorruptionAbility() };
            StartCoroutine(ChooseDirection());
            StartCoroutine(TargetAndCast());
        }

        IEnumerator ChooseDirection()
        {
            while (true)
            {
                currentDirection = Random.Range(0, 4);
                animator.SetInteger("Direction(NSEW)", currentDirection);
                yield return new WaitForSeconds(DirChangeInterval);
            }
        }

        IEnumerator TargetAndCast()
        {
            var targeting = GetComponent<Targeting>();
            while (true)
            {
                targeting.SwitchTarget();
                abilityManager.UseAbility(0, targeting.CurrentTarget);
                yield return new WaitForSeconds(DirChangeInterval);
            }
        }

        // Update is called once per frame
        void Update()
        {
            var velocityVector = new Vector3();
            switch (currentDirection)
            {
                case 0:
                    velocityVector.y = 1;
                    break;
                case 1:
                    velocityVector.x = 1;
                    break;
                case 2:
                    velocityVector.y = -1;
                    break;
                case 3:
                    velocityVector.x = -1;
                    break;
            }
            transform.position = transform.position + velocityVector * Time.deltaTime * Speed;
            animator.SetBool("Walking", velocityVector.sqrMagnitude > 0);
        }
    }
}
