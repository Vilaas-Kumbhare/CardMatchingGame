using CardMatching.Scripts.StateMachine;

namespace CardMatching.Scripts.GameStateMachine
{
    public class CardMatchinStateMachine
    {
        private IState _currentState;
        
        public void SetState(IState state)
        {
            _currentState = state;
            _currentState.Enter();
        }
        
        public void ExecuteCurrentState()
        {
            _currentState?.Execute();
        }
    }
}

