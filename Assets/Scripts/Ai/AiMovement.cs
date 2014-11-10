using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Abilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Ai
{
    public class AiMovement : MonoBehaviour
    {
        public enum MovementMode
        {
            RandomWalk,
            LockedOnTarget,
            ReturnToHome
        }
        public MovementMode CurrentMovementMode;
        public float Speed = 1;
        public float DirChangeInterval = 1;
        private int currentDirection;


        //Things on the gameobject we need
        private Animator animator;
        private Targeter targeter;
        private AiBattle battler;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            targeter = GetComponent<Targeter>();
            battler = GetComponent<AiBattle>();
            StartCoroutine(RandomWalk());
        }

        IEnumerator RandomWalk()
        {
            while (true)
            {
                if (CurrentMovementMode == MovementMode.RandomWalk)
                {
                    currentDirection = Random.Range(0, 4);
                }
                yield return new WaitForSeconds(DirChangeInterval);
            }
        }


        // Update is called once per frame
        void Update()
        {
            var velocityVector = new Vector3();
            switch (CurrentMovementMode)
            {
                case MovementMode.RandomWalk:
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

                    if (targeter.CurrentTarget != null)
                    {
                        CurrentMovementMode = MovementMode.LockedOnTarget;
                    }

                    break;
                case MovementMode.LockedOnTarget:
                    var target = targeter.CurrentTarget;
                    if (battler.NeedsToMove)
                    {
                        var destinationLocation = battler.GetNodeDestinationLocation(target);
                        var deltaS = destinationLocation - (Vector2)transform.position;
                        velocityVector = deltaS.normalized;
                        GetComponent<Rigidbody2D>().velocity = velocityVector * Speed;
                        animator.SetBool("Walking", true);
                    }
                    else
                    {
                        animator.SetBool("Walking", false);
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    }
                    var dir = target.GetDirectionVectorTo(transform.position);
                    animator.SetFloat("DirX", dir.x);
                    animator.SetFloat("DirY", dir.y);
                    animator.SetFloat("VelX", velocityVector.x);
                    animator.SetFloat("VelY", velocityVector.y);
                    break;
                case MovementMode.ReturnToHome:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
