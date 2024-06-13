using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChessExample
{
    //sender
    public class ChessGridEventHandler : MonoBehaviour
    {
        private GraphicRaycaster _graphicRayCaster;
        PointerEventData m_PointerEventData;
        EventSystem m_EventSystem;
        private ChessGrid _chessGrid;
        private IChessSelectionState _currentClickState;
        private TurnManager _turnManager;

        private void Awake()
        {
            _chessGrid = FindObjectOfType<ChessGrid>();
            _graphicRayCaster = GetComponentInParent<GraphicRaycaster>();
            m_EventSystem = FindObjectOfType<EventSystem>();
            _turnManager = FindObjectOfType<TurnManager>();
            _currentClickState = new UnselectedState(_chessGrid, _turnManager);
        }

        void Update()
        {
            //Check if the left Mouse button is clicked
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnClick();
            }
        }

        private void OnClick()
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            _graphicRayCaster.Raycast(m_PointerEventData, results);

            ChessCell selectedCell = null;

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                selectedCell = result.gameObject.GetComponent<ChessCell>();
                if (selectedCell != null) break;
            }
            _currentClickState = _currentClickState.Execute(selectedCell);
        }

        public void UndoLastMove()
        {
            if (MoveHistory.MoveHistoryStack.Count > 0) MoveHistory.MoveHistoryStack.Pop().Undo();
        }
    }
}