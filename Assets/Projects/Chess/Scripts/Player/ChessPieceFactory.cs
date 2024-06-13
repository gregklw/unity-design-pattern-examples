using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class ChessPieceFactory : MonoBehaviour
    {
        private ChessGrid _chessGrid;
        [SerializeField] private PlayerSpecificValues _player1Values;
        [SerializeField] private PlayerSpecificValues _player2Values;

        // Start is called before the first frame update
        void Start()
        {
            CreatePlayerSet(_player1Values, 0, 1);
            CreatePlayerSet(_player2Values, _chessGrid.ChessGridSize - 1, _chessGrid.ChessGridSize - 2);
        }

        private void CreatePlayerSet(PlayerSpecificValues playerSpecificValues, int row, int pawnRow)
        {
            _chessGrid = GetComponent<ChessGrid>();
            AddPieceToCell(playerSpecificValues.RookPrefab, playerSpecificValues.PlayerEnum, 0, row);
            AddPieceToCell(playerSpecificValues.HorsePrefab, playerSpecificValues.PlayerEnum, 1, row);
            AddPieceToCell(playerSpecificValues.BishopPrefab, playerSpecificValues.PlayerEnum, 2, row);
            AddPieceToCell(playerSpecificValues.QueenPrefab, playerSpecificValues.PlayerEnum, 3, row);
            AddPieceToCell(playerSpecificValues.KingPrefab, playerSpecificValues.PlayerEnum, 4, row);
            AddPieceToCell(playerSpecificValues.BishopPrefab, playerSpecificValues.PlayerEnum, 5, row);
            AddPieceToCell(playerSpecificValues.HorsePrefab, playerSpecificValues.PlayerEnum, 6, row);
            AddPieceToCell(playerSpecificValues.RookPrefab, playerSpecificValues.PlayerEnum, 7, row);
            int gridSize = _chessGrid.ChessGridSize;
            for (int i = 0; i < gridSize; i++)
            {
                AddPieceToCell(playerSpecificValues.PawnPrefab, playerSpecificValues.PlayerEnum, i, pawnRow);
            }
        }

        public void AddPieceToCell(ChessPiece chessPiecePrefab, PlayerEnum playerOwnership, int x, int y)
        {
            ChessCell cellToAddPiece = _chessGrid.GetTargetCell(x, y);
            ChessPiece chessPiece = Instantiate(chessPiecePrefab, cellToAddPiece.transform);
            chessPiece.PlayerOwnership = playerOwnership;
            cellToAddPiece.CurrentChessPiece = chessPiece;
        }
    }
}

