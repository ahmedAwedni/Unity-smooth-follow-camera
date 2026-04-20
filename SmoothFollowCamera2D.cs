// SmoothFollowCamera2D.cs
using UnityEngine;

[DisallowMultipleComponent]
public class SmoothFollowCamera2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private Vector2 offset = new Vector2(0f, 2f);
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Dead Zone")]
    [Tooltip("Width and height of the dead zone. The target can move freely inside this box.")]
    [SerializeField] private Vector2 deadZoneSize = new Vector2(3f, 2f);

    [Header("Axis Lock")]
    [SerializeField] private bool lockX = false;
    [SerializeField] private bool lockY = false;

    private float fixedZ;
    private Vector2 currentFocus;

    private void Awake()
    {
        fixedZ = transform.position.z;
        if (target != null) currentFocus = target.position;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Calculate X dead zone bounds
        float distanceX = target.position.x - currentFocus.x;
        if (Mathf.Abs(distanceX) > deadZoneSize.x / 2f)
        {
            currentFocus.x = target.position.x - Mathf.Sign(distanceX) * (deadZoneSize.x / 2f);
        }

        // Calculate Y dead zone bounds
        float distanceY = target.position.y - currentFocus.y;
        if (Mathf.Abs(distanceY) > deadZoneSize.y / 2f)
        {
            currentFocus.y = target.position.y - Mathf.Sign(distanceY) * (deadZoneSize.y / 2f);
        }

        Vector3 desiredPosition = new Vector3(
            lockX ? transform.position.x : currentFocus.x + offset.x,
            lockY ? transform.position.y : currentFocus.y + offset.y,
            fixedZ
        );

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;
    }

    // Draws a helpful green box in the Scene view to visualize the dead zone
    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Vector3 center = Application.isPlaying ? (Vector3)currentFocus : target.position;
            Gizmos.DrawWireCube(center, deadZoneSize);
        }
    }
}
