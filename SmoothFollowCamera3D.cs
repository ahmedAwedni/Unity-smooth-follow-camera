// SmoothFollowCamera3D.cs
using UnityEngine;

[DisallowMultipleComponent]
public class SmoothFollowCamera3D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Dead Zone")]
    [Tooltip("How far the target can move before the camera starts following.")]
    [SerializeField] private float deadZoneRadius = 2f;

    // The point the camera is actually looking at and following
    private Vector3 currentFocus;

    private void Start()
    {
        if (target != null) currentFocus = target.position;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Check distance between current focus point and the target
        float distance = Vector3.Distance(target.position, currentFocus);

        // If target moves outside the dead zone, pull the focus point with it
        if (distance > deadZoneRadius)
        {
            Vector3 direction = (target.position - currentFocus).normalized;
            currentFocus = target.position - (direction * deadZoneRadius);
        }

        Vector3 desiredPosition = currentFocus + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(currentFocus);
    }

    // Draws a helpful green sphere in the Scene view to visualize the dead zone in the editor
    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawWireSphere(Application.isPlaying ? currentFocus : target.position, deadZoneRadius);
        }
    }
}
