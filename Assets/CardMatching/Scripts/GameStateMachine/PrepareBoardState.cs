using System;
using CardMatching.Scripts.Board;
using UnityEngine;


namespace CardMatching.Scripts.StateMachine
{
    public class PrepareBoardState:IState
    {
        private readonly IBoard _boardManager;
        private readonly Action _callback;
        
        public PrepareBoardState(IBoard boardManager, Action callback)
        {
            _boardManager = boardManager;
            _callback = callback;
        }

        public void Enter()
        {
            _boardManager.SetUpCardsOnBoard();
            Exit();
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            _callback?.Invoke();
        }
    }
}

