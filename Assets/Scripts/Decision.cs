using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide (StateController controller);
    }
}