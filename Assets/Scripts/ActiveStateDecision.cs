using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide (StateController controller)
        {
            var chaseTargetisActive = controller.ChaseTarget.gameObject.activeSelf;
            return chaseTargetisActive;
        }
    }
}