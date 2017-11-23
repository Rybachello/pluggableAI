using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act (StateController controller);
    }
}