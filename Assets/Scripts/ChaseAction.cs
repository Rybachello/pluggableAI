using UnityEngine;

namespace Assets.Scripts {
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
    public class ChaseAction : Action
    {
        public override void Act (StateController controller)
        {
            Chase(controller);
        }

        private void Chase (StateController controller)
        {
            controller.NavMeshAgent.destination = controller.ChaseTarget.position;
            controller.NavMeshAgent.isStopped = false;
        }
    }
}