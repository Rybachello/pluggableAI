using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/State")]
    public class State : ScriptableObject
    {
        public List<Action> Actions;
        public List<Transition> Transitions;
        public Color SceneGizmosColor = Color.black;

        public void UpdateState (StateController controller)
        {
            DoActions(controller);
            CheckTransition(controller);
        }
        
        private void DoActions (StateController controller)
        {
            Actions.ForEach(action => action.Act(controller));
        }

        private void CheckTransition(StateController controller)
        {
            Transitions.ForEach(transition => {
                    var decisionSucceeded = transition.Decision.Decide(controller);
                    controller.TransitionToState(decisionSucceeded ? transition.TrueState : transition.FalseState);
                }
            );

        }
    }
}