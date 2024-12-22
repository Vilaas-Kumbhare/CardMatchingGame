using System;
using System.Collections;
using CardMatching.Scripts.Board;
using CardMatching.Scripts.Score;
using UnityEngine;


namespace CardMatching.Scripts.StateMachine
{
    public class CheckCardSelectionState:IState
    {
        private readonly IBoard _boardManager;
        private readonly Action _callback;
        private readonly MonoBehaviour _monoBehaviour;
        private readonly IScore _score;
        
        public CheckCardSelectionState(IBoard boardManager, Action callback, MonoBehaviour mono, IScore score)
        {
            _boardManager = boardManager;
            _callback = callback;
            _monoBehaviour = mono;
            _score = score;
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
            yield return new WaitForSeconds(1.5f);
            if (_boardManager.CheckMatch())
            {
                _boardManager.RemoveCardsFromTheBoard();
                _score.UpdateScore(true);
            }
            else
            {
                _boardManager.HideSelectedCards();
                _score.UpdateScore(false);
            }
            Exit();
        }
    }
}

