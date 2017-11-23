using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Scan")]
    public class ScanDecision : Decision
    {
        public override bool Decide (StateController controller)
        {
            var noEnemyInSight = Scan(controller);
            return noEnemyInSight;
        }

        private bool Scan (StateController controller)
        {
            controller.NavMeshAgent.isStopped = true;
            controller.transform.Rotate(0, controller.EnemyStats.searchingTurnSpeed * Time.deltaTime, 0);
            return controller.CheckIfCountDownElapsed(controller.EnemyStats.searchDuration);
        }
    }
}