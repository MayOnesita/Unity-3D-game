using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    /// <summary>
    /// This class is used to control the camera that follows an specific player.
    /// </summary>
    /// <remarks>
    ///  The variable _offset is a Vector3 that represents the initial distance between the camera and the player it is following.
    ///  The variable smoothTime is a float representing the time taken for the camera to move from its current position to the desired position.
    /// </remarks>

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