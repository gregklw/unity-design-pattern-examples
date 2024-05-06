using UnityEngine;

namespace MazeExample
{
    public class MoveLeftCommand : IMazeCommand
    {
        private CharacterToMove _characterToMove;
        private Vector2 _direction;
        public MoveLeftCommand(CharacterToMove characterToMove)
        {
            _characterToMove = characterToMove;
            _direction = Vector2.left;
        }
        public void Execute()
        {
            _characterToMove?.Move(_direction);
        }

        public void Undo()
        {
            _characterToMove?.Move(-_direction);
        }
    }
}
