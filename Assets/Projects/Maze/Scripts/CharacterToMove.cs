using UnityEngine;

//receiver
namespace MazeExample 
{
    public class CharacterToMove : MonoBehaviour
    {
        public void Move(Vector2 amountToMove)
        {
            Vector2 newPosition = (Vector2) transform.position + amountToMove;
            transform.position = newPosition;
        }
    }
}