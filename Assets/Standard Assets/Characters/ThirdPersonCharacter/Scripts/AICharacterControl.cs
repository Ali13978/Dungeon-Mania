using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    //[RequireComponent(typeof (NavMeshAgent))]
    //[RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        //public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        //public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Vector3 target;                                    // target to aim for
        public Animator animator;
        public UnityEngine.AI.NavMeshAgent agent;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            //character = GetComponent<ThirdPersonCharacter>();
            animator = GetComponent<Animator>();

	        //agent.updateRotation = false;
	        //agent.updatePosition = true;
        }


        private void Update()
        {
            if (CrossPlatformInputManager.GetButton("Fire1") && Time.timeScale!=0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.tag == "ground" || hit.transform.tag == "history")
                    {
                         target = hit.point;
                        transform.rotation = Quaternion.LookRotation(target - transform.position);
                        agent.SetDestination(target);
                        animator.SetFloat("speed", 1f);
                    }
                }
            }

            if (target != null) {
                
            }

            if (agent.remainingDistance < agent.stoppingDistance)  animator.SetFloat("speed", 0f);

            /*
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
            */
        }


        public void SetTarget(Transform target)
        {
            //this.target = target;
        }
    }
}
