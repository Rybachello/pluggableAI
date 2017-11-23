namespace Assets.Scripts
{
    [System.Serializable]
    public class Transition
    {
        public Decision Decision;
        public State TrueState;
        public State FalseState;
    }
}