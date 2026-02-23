using UnityEngine;

[DisallowMultipleComponent]
public class SmoothFollowCamera2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private Vector2 offset = new Vector2(0f, 2f);
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Axis Lock")]
    [SerializeField] private bool lockX = false;
    [SerializeField] private bool lockY = false;

    private float fixedZ;

    private void Awake()
    {
        fixedZ = transform.position.z; 
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(
            lockX ? transform.position.x : target.position.x + offset.x,
            lockY ? transform.position.y : target.position.y + offset.y,
            fixedZ
        );

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;
    }
}
