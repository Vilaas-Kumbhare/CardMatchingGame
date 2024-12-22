using System;
using System.Collections;
using CardMatching.Scripts.Board;
using UnityEngine;


namespace CardMatching.Scripts.StateMachine
{
    public class HideAllCardsAfterDelayState:IState
    {
        private readonly IBoard _boardManager;
        private readonly Action _callback;
        private readonly MonoBehaviour _monoBehaviour;
        
        public HideAllCardsAfterDelayState(IBoard boardManager, Action callback, MonoBehaviour mono)
        {
            _boardManager = boardManager;
            _callback = callback;
            _monoBehaviour = mono;
        }

        public void Enter()
        {
            _monoBehaviour.StartCoroutine(ExecuteSequence());
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            _callback?.Invoke();
        }

        private IEnumerator ExecuteSequence()
        {
            yield return new WaitForSeconds(2f);
            _boardManager.HideAllCards();

            Exit();
        }
    }
}

