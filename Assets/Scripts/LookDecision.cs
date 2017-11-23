using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
    public class LookDecision : Decision
    {
        public override bool Decide (StateController controller)
        {
            var targetVisible = Look(controller);
            return targetVisible;
        }

        private bool Look (StateController controller)
        {
            RaycastHit hit;

            if (Physics.SphereCast(controller.Eyes.transform.position, controller.EnemyStats.lookSphereCastRadius,
                    controller.Eyes.forward, out hit, controller.EnemyStats.lookRange) &&
                hit.collider.CompareTag("Player")) {
                controller.ChaseTarget = hit.transform;
                return true;
            } else {
                return false;
            }
        }
    }
}