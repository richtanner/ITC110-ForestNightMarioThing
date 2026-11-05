using UnityEngine;
using UnityEngine.InputSystem;

public class WarpPipe: MonoBehaviour
{
    public enum EnterDirection
    {
        up,
        down,
        right,
        left
    }


    [SerializeField] InputActionReference playerMove;
    [SerializeField] Transform warpTarget;
    [SerializeField] GameObject playerCamera;
    [SerializeField] Transform cameraTarget;
    [SerializeField] EnterDirection enterDirection;
    [SerializeField] bool disableCameraAtDestination = false;
    [SerializeField] AudioClip warpSound;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // get input from Input System
            Vector2 directionP = playerMove.action.ReadValue<Vector2>();
            bool receivedInput = false;
            switch (enterDirection)
            {
                case EnterDirection.up:
                    if (directionP.y > 0)
                    {
                        receivedInput = true;
                    }
                    break;
                case EnterDirection.down:
                    //
                    if (directionP.y < 0)
                    {
                        receivedInput = true;
                    }
                    break;
                case EnterDirection.right:
                    if (directionP.x > 0)
                    {
                        receivedInput = true;
                    }
                    break;
                case EnterDirection.left:
                    if (directionP.x < 0)
                    {
                        receivedInput = true;
                    }
                    break;
                default:
                    Debug.LogError("You forgot to set the entrance direction to the warp pipe!");
                    break;

            }
            
            if (receivedInput)
            {
                AudioSource.PlayClipAtPoint(warpSound, transform.position);
                AudioSource.PlayClipAtPoint(warpSound, warpTarget.transform.position);
                // maybe some smoke and mirrors here, but for now, ENERGIZE
                Vector3 cameraPos = playerCamera.transform.position;
                cameraPos.x = cameraTarget.position.x;
                playerCamera.transform.position = cameraPos;
                SmoothCameraFollow camControl = playerCamera.GetComponent<SmoothCameraFollow>();
                camControl.preventMovement = disableCameraAtDestination;
                other.gameObject.transform.position = warpTarget.position;
            }
        }
    }
}
