using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    //selectable object
    //should handle selectable tiles
    //receiver
    public abstract class ChessPiece : MonoBehaviour
    {
        private List<ChessCell> _legalMoveCells = new List<ChessCell>();
        private List<ChessCell> _legalCaptureCells = new List<ChessCell>();
        public Transform Transform => transform;
        public PlayerEnum PlayerOwnership { get; set; }
        public bool IsFirstMoveDone { get; set; } 
        public abstract void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y);

        public void Execute(ISelectableCommand command)
        {
            MoveHistory.MoveHistoryStack.Push(command);
            command.Execute();
        }

        public void ToggleLegalCells(bool isOn)
        {
            if (!isOn) 
            {
                foreach (ChessCell cell in _legalMoveCells)
                {
                    cell.ChangeHighlightColour(ChessCellStateColours.InactiveCellColour);
                }
                foreach (ChessCell cell in _legalCaptureCells)
                {
                    cell.ChangeHighlightColour(ChessCellStateColours.InactiveCellColour);
                }
                _legalMoveCells.Clear();
                _legalCaptureCells.Clear();
            }
            else
            {
                foreach (ChessCell cell in _legalMoveCells)
                {
                    cell.ToggleLegalCell(isOn);
                    cell.ChangeHighlightColour(ChessCellStateColours.LegalMoveCellColour);
                }
                foreach (ChessCell cell in _legalCaptureCells)
                {
                    cell.ToggleLegalCell(isOn);
                    cell.ChangeHighlightColour(ChessCellStateColours.LegalCaptureCellColour);
                }
            }
        }

        protected void EnableLegalCellsInTargetDirection(Func<int, int, ChessCell> directionDelegate, int xCoordinate, int yCoordinate, int maxTravelCount = int.MaxValue)
        {
            ChessCell currentCell = directionDelegate(xCoordinate, yCoordinate);
            int travelCount = 0;
            while (travelCount < maxTravelCount && currentCell != null)
            {
                if (currentCell.CurrentChessPiece != null)
                {
                    if (currentCell.CurrentChessPiece.PlayerOwnership != PlayerOwnership)
                        _legalCaptureCells.Add(currentCell);
                    break;
                }
                else
                {
                    _legalMoveCells.Add(currentCell);
                }
                currentCell = directionDelegate(currentCell.CoordinateX, currentCell.CoordinateY);
                travelCount++;
            }
            ToggleLegalCells(true);
        }
    }
}