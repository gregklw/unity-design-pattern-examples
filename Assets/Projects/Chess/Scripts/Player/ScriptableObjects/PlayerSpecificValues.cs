using UnityEngine;

namespace ChessExample
{
    [CreateAssetMenu(fileName = "New Player Specific Values", menuName = "Player Specific Values")]
    public class PlayerSpecificValues : ScriptableObject
    {
        [SerializeField] private PlayerEnum _playerEnum;
        [SerializeField] private ChessPiece _rookPrefab;
        [SerializeField] private ChessPiece _horsePrefab;
        [SerializeField] private ChessPiece _queenPrefab;
        [SerializeField] private ChessPiece _bishopPrefab;
        [SerializeField] private ChessPiece _kingPrefab;
        [SerializeField] private ChessPiece _pawnPrefab;

        public PlayerEnum PlayerEnum => _playerEnum;
        public ChessPiece RookPrefab => _rookPrefab;
        public ChessPiece HorsePrefab => _horsePrefab;
        public ChessPiece QueenPrefab => _queenPrefab;
        public ChessPiece BishopPrefab => _bishopPrefab;
        public ChessPiece KingPrefab => _kingPrefab;
        public ChessPiece PawnPrefab => _pawnPrefab;
    }

    public enum PlayerEnum
    {
        PLAYER1,
        PLAYER2
    }
}


