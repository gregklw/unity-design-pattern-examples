using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessExample
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _turnCountText;
        [SerializeField] private TMP_Text _currentPlayerText;
        private int _turnCount;
        private PlayerEnum _currentPlayerTurn = PlayerEnum.PLAYER1;

        public Action OnCellCommand;
        public PlayerEnum CurrentPlayerTurn
        {
            get { return _currentPlayerTurn; }
            set { _currentPlayerTurn = value; }
        }

        private void Start()
        {
            UpdateTurnInfo();
        }

        private void OnEnable()
        {
            OnCellCommand += EndTurnActions;
        }

        private void OnDestroy()
        {
            OnCellCommand -= EndTurnActions;
        }

        private void EndTurnActions()
        {
            _currentPlayerTurn = _currentPlayerTurn == PlayerEnum.PLAYER1 ? PlayerEnum.PLAYER2 : PlayerEnum.PLAYER1;
            UpdateTurnInfo();
        }

        private void UpdateTurnInfo()
        {
            _currentPlayerText.text = $"Current Player: {_currentPlayerTurn}";
            _turnCountText.text = $"Turn: {++_turnCount}";
        }
    }
}

