using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class StateController : MonoBehaviour
    {
        public State CurrentState;
        public State RemainState;
        public EnemyStats EnemyStats;
        public Transform Eyes;

        [HideInInspector] public NavMeshAgent NavMeshAgent;
        [HideInInspector] public Complete.TankShooting TankShooting;
        [HideInInspector] public List<Transform> WayPointList;
        [HideInInspector] public int NextWayPoint;
        public Transform ChaseTarget;
        [HideInInspector] public float StateTimeElapsed;

        private bool _aiActive;

        private void Awake ( )
        {
            TankShooting = GetComponent<Complete.TankShooting>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update ( )
        {
            if (!_aiActive)
                return;
            CurrentState.UpdateState(this);
        }

        private void OnDrawGizmos ( )
        {
            if (CurrentState != null && Eyes != null) {
                Gizmos.color = CurrentState.SceneGizmosColor;
                Gizmos.DrawWireSphere(Eyes.transform.position, EnemyStats.lookSphereCastRadius);
            }
        }

        public void SetupAI (bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
        {
            WayPointList = wayPointsFromTankManager;
            _aiActive = aiActivationFromTankManager;
            if (_aiActive) {
                NavMeshAgent.enabled = true;
            } else {
                NavMeshAgent.enabled = false;
            }
        }

        public void TransitionToState (State nextState)
        {
            if (nextState != RemainState) {
                CurrentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed (float duration)
        {
            StateTimeElapsed += Time.deltaTime;
            return (StateTimeElapsed >= duration);
        }

        private void OnExitState ( )
        {
            StateTimeElapsed = 0;
        }
    }
}