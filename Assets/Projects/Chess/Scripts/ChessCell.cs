using System;
using UnityEngine;
using UnityEngine.UI;

namespace ChessExample
{
    //receiver
    public class ChessCell : MonoBehaviour
    {
        public ChessPiece CurrentChessPiece { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public bool IsLegalSelectableCell { get; set; }
        [SerializeField] private Image _background;
        [SerializeField] private Image _highlight;


        public void ChangeColour(Color color)
        {
            _background.color = color;
        }

        public void ChangeHighlightColour(Color color)
        {
            _highlight.color = color;
        }

        public void SetSize(int size)
        {
            _background.rectTransform.sizeDelta = new Vector2(size, size);
        }

        public void SetAnchoredPosition(Vector2 anchoredPosition)
        {
            _background.rectTransform.anchoredPosition = anchoredPosition;
        }

        public void ToggleLegalCell(bool isOn)
        {
            IsLegalSelectableCell = isOn;
        }
    }
    
}