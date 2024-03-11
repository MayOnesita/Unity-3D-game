using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform playerToFollow;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - playerToFollow.position;
    }

    private void LateUpdate()
    {
        Vector3 playerPosition = playerToFollow.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref _currentVelocity, smoothTime);
    }

}