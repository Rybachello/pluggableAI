using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "PluggableAI/State")]
    public class State : ScriptableObject
    {
        public List<Action> Actions;
        public Color SceneGizmosColor = Color.black;

        public void UpdateState (StateController controller) {
            DoActions(controller);
        }

        private void DoActions (StateController controller) {
            Actions.ForEach(action => action.Act(controller));
        }
    }
}