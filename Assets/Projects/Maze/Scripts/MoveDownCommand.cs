using UnityEngine;
namespace MazeExample
{
    public class MoveDownCommand : IMazeCommand
    {
        private CharacterToMove _characterToMove;
        private Vector2 _direction;
        public MoveDownCommand(CharacterToMove characterToMove)
        {
            _characterToMove = characterToMove;
            _direction = Vector2.down;
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