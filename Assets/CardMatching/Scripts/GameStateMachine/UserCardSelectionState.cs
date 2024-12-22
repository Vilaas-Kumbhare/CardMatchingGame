using System;
using CardMatching.Scripts.Board;


namespace CardMatching.Scripts.StateMachine
{
    public class UserCardSelectionState:IState
    {
        private readonly IBoard _boardManager;
        private readonly Action _callback;
        
        public UserCardSelectionState(IBoard boardManager, Action callback)
        {
            _boardManager = boardManager;
            _callback = callback;
        }

        public void Enter()
        {
        }

        public void Execute()
        {
            if(_boardManager.AreBothCardsSelected())
                Exit();
        }

        public void Exit()
        {
            _callback?.Invoke();
        }
    }
}

