using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
    public class AttackAction : Action
    {
        public override void Act (StateController controller)
        {
            Attack(controller);
        }

        private void Attack (StateController controller)
        {
            RaycastHit hit;

            Debug.DrawRay(controller.Eyes.position,
                controller.Eyes.forward.normalized * controller.EnemyStats.attackRange, Color.red);

            if (Physics.SphereCast(controller.Eyes.position, controller.EnemyStats.lookSphereCastRadius,
                    controller.Eyes.forward, out hit, controller.EnemyStats.attackRange)
                && hit.collider.CompareTag("Player")) {
                if (controller.CheckIfCountDownElapsed(controller.EnemyStats.attackRate)) {
                    controller.TankShooting.Fire(controller.EnemyStats.attackForce, controller.EnemyStats.attackRate);
                }
            }
        }
    }
}