using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public class StateController : MonoBehaviour
{
    public State CurrentState;
    public EnemyStats EnemyStats;
    public Transform Eyes;
    
    [HideInInspector] public NavMeshAgent NavMeshAgent;
    [HideInInspector] public Complete.TankShooting TankShooting;
    [HideInInspector] public List<Transform> WayPointList;
    [HideInInspector] public int NextWayPoint;

    private bool _aiActive;

    private void Awake ( ) {
        TankShooting = GetComponent<Complete.TankShooting>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update ( ) {
        if (!_aiActive)
            return;
        CurrentState.UpdateState(this);
    }

    private void OnDrawGizmos ( ) {
        if (CurrentState != null && Eyes != null) {
            Gizmos.color = CurrentState.SceneGizmosColor;
            Gizmos.DrawWireSphere(Eyes.transform.position, EnemyStats.lookSphereCastRadius);
        }
    }

    public void SetupAI (bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager) {
        WayPointList = wayPointsFromTankManager;
        _aiActive = aiActivationFromTankManager;
        if (_aiActive) {
            NavMeshAgent.enabled = true;
        } else {
            NavMeshAgent.enabled = false;
        }
    }
}