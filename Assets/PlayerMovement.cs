using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;

    public float speed = 5f;
    public float wallBounceDistance = 0.08f;

    private bool touchingWall = false;
    private CameraShake cameraShake;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        if (Camera.main != null)
        {
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
        else
        {
            Debug.LogError("No Main Camera found!");
        }
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0, z).normalized;

        if (move.magnitude > 0)
        {
            CollisionFlags hit =
                playerController.Move(move * speed * Time.deltaTime);

            bool hitWall = (hit & CollisionFlags.Sides) != 0;

            // Bonk only once when first touching the wall
            if (hitWall && !touchingWall)
            {
                playerController.Move(-move * wallBounceDistance);
                touchingWall = true;
                if (cameraShake != null)
                {
                    StartCoroutine(cameraShake.Shake(0.08f, 0.03f));
                }
            }

            // Reset when player moves away from the wall
            if (!hitWall)
            {
                touchingWall = false;
            }
        }
        else
        {
            // No movement input, allow future bonks
            touchingWall = false;
        }
    }
}