using UnityEngine;

public class SwipeCameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset = new Vector3(0, 5, -10);
    public float sensitivity = 0.1f;
    public float verticalRotationLimit = 60f; 
    public float minVerticalRotation = 10f;    
    public float maxVerticalHeight = 15f;      

    private Vector2 touchStartPosition;
    private float currentXRotation = 0f;
    private float currentYRotation = 0f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned in the inspector");
        }

        
        UpdateCameraPosition();
    }

    void Update()
    {
        HandleTouchInput();
        UpdateCameraPosition();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            
            if (touch.position.x > Screen.width / 2)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPosition = touch.position;
                        break;

                    case TouchPhase.Moved:
                        Vector2 touchDelta = touch.position - touchStartPosition;

                        
                        currentYRotation += touchDelta.x * sensitivity;
                        currentXRotation -= touchDelta.y * sensitivity;

                        
                        currentXRotation = Mathf.Clamp(currentXRotation, -minVerticalRotation, verticalRotationLimit);

                        touchStartPosition = touch.position;
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        break;
                }
            }
        }


        if (Input.touchCount > 1)
        {
            Touch touch = Input.GetTouch(1);


            if (touch.position.x > Screen.width / 2)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPosition = touch.position;
                        break;

                    case TouchPhase.Moved:
                        Vector2 touchDelta = touch.position - touchStartPosition;


                        currentYRotation += touchDelta.x * sensitivity;
                        currentXRotation -= touchDelta.y * sensitivity;


                        currentXRotation = Mathf.Clamp(currentXRotation, -minVerticalRotation, verticalRotationLimit);

                        touchStartPosition = touch.position;
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        break;
                }
            }
        }
    }

    void UpdateCameraPosition()
    {
        
        Quaternion cameraRotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);

        
        Vector3 newCameraPosition = player.position + cameraRotation * cameraOffset;

        
        if (newCameraPosition.y > player.position.y + maxVerticalHeight)
        {
            newCameraPosition.y = player.position.y + maxVerticalHeight;
        }

        
        transform.position = newCameraPosition;

        
        transform.LookAt(player.position + Vector3.up * cameraOffset.y);
    }
}
