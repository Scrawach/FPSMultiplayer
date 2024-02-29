using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private CharacterMovement _movement;

    private void Update()
    {
        var inputDirection = ReadInputVector();
        _movement.Move(inputDirection);
    }

    private static Vector2 ReadInputVector() => 
        new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis)).normalized;
}