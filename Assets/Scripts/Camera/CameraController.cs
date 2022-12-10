using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    private Vector3 _offset;
    private Transform _transform;

    private void Awake()
    {
        _offset = transform.position - _player.position;
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        var position = _transform.position;
        var newPosition = new Vector3(position.x, position.y, _offset.z + _player.position.z);
        _transform.position = newPosition;
    }
}
