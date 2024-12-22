using CardMatching.Scripts.Board;
using UnityEngine;
using CardMatching.Scripts.GameStateMachine;
using CardMatching.Scripts.StateMachine;
using CardMatching.Scripts.Score;

namespace CardMatching.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] 
        private BoardManager _boardManager;
        [SerializeField]
        private ScoreManager _score;
        private CardMatchinStateMachine _stateMachine;
        private StateSwitch _currentState;
        private void Awake()
        {
            _stateMachine = new CardMatchinStateMachine();
        }

        private void Start()
        {
            _currentState = StateSwitch.PrepareBoard;
            UpdateState();
        }

        private void UpdateState()
        {
            switch (_currentState)
            {
                case StateSwitch.PrepareBoard:
                    _stateMachine.SetState(new PrepareBoardState(_boardManager, () =>
                    {
                        SetNextState(StateSwitch.HideAllCards);
                    }));
                    break;
                
                case StateSwitch.HideAllCards:
                    _stateMachine.SetState(new HideAllCardsAfterDelayState(_boardManager, () =>
                    {
                        SetNextState(StateSwitch.UserCardSelection);
                    },this));
                    break;
                
                case StateSwitch.UserCardSelection:
                    _boardManager.EnableBoardCardInteraction(true);
                    _stateMachine.SetState(new UserCardSelectionState(_boardManager, () =>
                    {
                        SetNextState(StateSwitch.CheckCardsSelected);
                    }));
                    break;
                
                case StateSwitch.CheckCardsSelected:
                    _boardManager.EnableBoardCardInteraction(false);
                    _stateMachine.SetState(new CheckCardSelectionState(_boardManager, () =>
                    {
                        SetNextState(StateSwitch.NextTurn);
                    }, this,_score));
                    break;
                
                case StateSwitch.NextTurn:
                    SetNextState(_boardManager.IsBoardCompleted()
                        ? StateSwitch.EndGame
                        : StateSwitch.UserCardSelection);
                    break;
                
                case StateSwitch.EndGame:
                    _stateMachine.SetState(new GameEndingState());
                    break;
            }
        }

        private void SetNextState(StateSwitch nextState)
        {
            _currentState = nextState;
            UpdateState();
        }

        private void Update()
        {
            _stateMachine.ExecuteCurrentState();
        }
    }
    
    
    enum StateSwitch
    {
        PrepareBoard,
        HideAllCards,
        UserCardSelection,
        CheckCardsSelected,
        NextTurn,
        EndGame
    }
}
