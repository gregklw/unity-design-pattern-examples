using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class ChessGrid : MonoBehaviour
    {
        private const int GridSize = 8;
        public int ChessGridSize => GridSize;
        private const int CellSize = 75;

        private ChessCell[,] _chess2dArray = new ChessCell[GridSize, GridSize];

        [SerializeField] private Color _color1, _color2;
        [SerializeField] private ChessCell _cellPrefab;

        //private delegate ChessCell CellTraversalCallback(int x, int y);
        //private CellTraversalCallback _cellTraversalCallback;

        private void Awake()
        {
            CreateChessGrid();
        }

        private void CreateChessGrid()
        {
            float offset = CellSize * -0.5f * GridSize + CellSize * 0.5f;
            Vector2 offsetPosition = new Vector2(offset, offset);

            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    Color cellColor = (x + y) % 2 == 0 ? _color1 : _color2;
                    ChessCell cell = Instantiate(_cellPrefab, transform);
                    cell.ChangeColour(cellColor);
                    cell.SetSize(CellSize);
                    cell.SetAnchoredPosition(new Vector2(x, y) * CellSize + offsetPosition);
                    _chess2dArray[x, y] = cell;
                    cell.CoordinateX = x;
                    cell.CoordinateY = y;
                }
            }
        }

        public ChessCell GetTargetCell(int x, int y)
        {
            return _chess2dArray[x, y];
        }

        public ChessCell GetUpwardCell(int x, int y)
        {
            return y >= GridSize - 1 ? null : _chess2dArray[x, y + 1];
        }

        public ChessCell GetDownwardCell(int x, int y)
        {
            return y <= 0 ? null : _chess2dArray[x, y - 1];
        }

        public ChessCell GetLeftwardCell(int x, int y)
        {
            return x <= 0 ? null : _chess2dArray[x - 1, y];
        }

        public ChessCell GetRightwardCell(int x, int y)
        {
            return x >= GridSize - 1 ? null : _chess2dArray[x + 1, y];
        }

        public ChessCell GetUpwardLeftCell(int x, int y)
        {
            return y >= GridSize - 1 || x <= 0 ? null : _chess2dArray[x - 1, y + 1];
        }

        public ChessCell GetUpwardRightCell(int x, int y)
        {
            return y >= GridSize - 1 || x >= GridSize - 1 ? null : _chess2dArray[x + 1, y + 1];
        }
        
        public ChessCell GetDownwardLeftCell(int x, int y)
        {
            return y <= 0 || x <= 0 ? null : _chess2dArray[x - 1, y - 1];
        }

        public ChessCell GetDownwardRightCell(int x, int y)
        {
            return y <= 0 || x >= GridSize - 1 ? null : _chess2dArray[x + 1, y - 1];
        }

        //private List<ChessCell> GetAllPossibleCellsInTargetDirection(CellTraversalCallback cellTraversalCallback, int x, int y)
        //{
        //    List<ChessCell> traversedCells = new List<ChessCell>();
        //    ChessCell currentCell = cellTraversalCallback(x, y);
        //    while (currentCell != null)
        //    {
        //        traversedCells.Add(currentCell);
        //        currentCell = cellTraversalCallback(currentCell.CoordinateX, currentCell.CoordinateY);
        //    }
        //    return traversedCells;
        //}

        //public List<ChessCell> GetAllPossibleUpwardCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetUpwardCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleDownwardCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetDownwardCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleLeftwardCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetLeftwardCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleRightwardCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetRightwardCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleUpwardLeftCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetUpwardLeftCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleUpwardRightCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetUpwardRightCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleDownwardLeftCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetDownwardLeftCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}

        //public List<ChessCell> GetAllPossibleDownwardRightCells(int x, int y)
        //{
        //    _cellTraversalCallback = GetDownwardRightCell;
        //    return GetAllPossibleCellsInTargetDirection(_cellTraversalCallback, x, y);
        //}
    }
}