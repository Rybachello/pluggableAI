using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/Action/Patrol")]
    public class PatrolAction : Action
    {
        public override void Act (StateController controller)
        {
            Patrol(controller);
        }

        private void Patrol (StateController controller)
        {
            controller.NavMeshAgent.destination = controller.WayPointList[controller.NextWayPoint].position;
            controller.NavMeshAgent.isStopped = false;
            if (controller.NavMeshAgent.remainingDistance <= controller.NavMeshAgent.stoppingDistance &&
                !controller.NavMeshAgent.pathPending) {
                var nextPoint = (controller.NextWayPoint + 1) % controller.WayPointList.Count;
                controller.NextWayPoint = nextPoint;
            }
        }
    }
}