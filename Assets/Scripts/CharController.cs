using UnityEngine;

namespace PixelWizards.GameSystem.Controllers
{
    /// <summary>
    /// Simple camera-relative character controller (similar to GTA / Zelda etc)
    /// </summary>
    public class CharController : MonoBehaviour
    {
        [Header("References")]
        public Animator animator;
        public Transform invisibleCameraOrigin;

        [Header("Config Vars")]
        public float walkSpeed = 1.0f;
        public float runSpeed = 6f;
        public float moveThreshold = 0.1f;
        public float gravity = 20.0f;
        
        private float desiredSpeed = 0f;
        private float currentSpeed = 0f;
        
        private Vector3 moveDirection = Vector3.zero;
        
        private Vector3 forward;
        private Vector3 right;
        private float hMove;
        private float vMove;
        private Quaternion cameraRot;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // camera-relative movement
            forward = invisibleCameraOrigin.forward;
            forward.y = 0;
            forward = forward.normalized;
            right = new Vector3(forward.z, 0, -forward.x);

            // grab input
            hMove = Input.GetAxis("Horizontal");
            vMove = Input.GetAxis("Vertical");

            // figure out which direction we're going
            moveDirection = (hMove * right + vMove * forward).normalized;

            // apply move speed - add run / other move modes and apply their movement speed in a similar manner
            desiredSpeed = walkSpeed;
            moveDirection *= Mathf.Lerp(currentSpeed, desiredSpeed, Time.deltaTime);

            // apply gravity
            gravity *= (Time.deltaTime * 50); // multiply delta time by magic # to get gravity working properly. wee
            // apply gravity
            moveDirection.y -= gravity;

            // look the way we are moving (rotates to face direction)
            moveDirection.y = 0f;
            currentSpeed = moveDirection.magnitude;
            if (currentSpeed > moveThreshold)
            {
                // tell the animation system how fast we are going
                animator.SetFloat("Speed", currentSpeed);

                // Preserve the camera rotation when we rotate the player
                cameraRot = invisibleCameraOrigin.rotation;

                transform.rotation = Quaternion.LookRotation(moveDirection);

                invisibleCameraOrigin.rotation = cameraRot;
            }
            else
            {
                // tell the animation system that we've stopped
                animator.SetFloat("Speed", 0f);
            }

            Debug.DrawRay(transform.position, forward, Color.green, 1.0f);
        }
    }
}