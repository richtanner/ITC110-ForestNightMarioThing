using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    [SerializeField] Transform target;
    public bool preventMovement = false;
    [SerializeField] bool followOnY = true;
    [SerializeField] bool canGoBackwards = true;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (!preventMovement)
        {
            Vector3 targetPosition = target.position + offset;
            targetPosition.z = transform.position.z;
            if (!followOnY)
            {
                targetPosition.y = transform.position.y;
            }
            if (!canGoBackwards && targetPosition.x < transform.position.x)
            {
                targetPosition.x = transform.position.x;
            }

            transform.position = Vector3.SmoothDamp(transform.position,
                targetPosition, ref velocity, damping);
        }
    }
}
