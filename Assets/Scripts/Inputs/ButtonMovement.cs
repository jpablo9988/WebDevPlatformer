using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player

    private bool moveUp, moveDown, moveLeft, moveRight;

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (moveUp) movement += Vector3.forward;
        if (moveDown) movement += Vector3.back;
        if (moveLeft) movement += Vector3.left;
        if (moveRight) movement += Vector3.right;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    public void MoveUp(bool isPressed) { moveUp = isPressed; }
    public void MoveDown(bool isPressed) { moveDown = isPressed; }
    public void MoveLeft(bool isPressed) { moveLeft = isPressed; }
    public void MoveRight(bool isPressed) { moveRight = isPressed; }
}
