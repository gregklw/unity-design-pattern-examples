using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TurnOn()
    {
        _spriteRenderer.color = Color.yellow;
    }
}
