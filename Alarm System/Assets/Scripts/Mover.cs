using UnityEngine;

public class Mover : MonoBehaviour
{
    public void Move(Vector3 direction, float movementSpeed)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
    }
}