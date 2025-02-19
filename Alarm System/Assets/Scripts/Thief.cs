using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector3 _direction;

    private Mover _mover;

    public Vector3 MovementStep => _movementSpeed * _direction;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.Move(_direction, _movementSpeed);
    }
}
