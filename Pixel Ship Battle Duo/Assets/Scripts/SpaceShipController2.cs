using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShipController2: MonoBehaviour
{
	// Movement speeds
	public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
	private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;

	// Acceleration rates
	private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

	// Look sensitivity
	public float lookRateSpeed = 90f;
	private Vector2 lookInput, screenCenter, mouseDistance;

	// Roll input and settings
	private float rollInput;
	public float rollSpeed = 90f, rollAcceleration = 3.5f;

	// Rigidbody reference
	private Rigidbody rb;

	// Camera follow settings
	public Transform cameraTransform;
	public Vector3 cameraOffset = new Vector3(0f, 3f, -8f);  // Offset relative to spaceship
	public float cameraFollowSpeed = 10f; // Speed at which the camera will follow

	// Start is called before the first frame update
	void Start()
	{
		// Initialize screen center
		screenCenter.x = Screen.width * 0.5f;
		screenCenter.y = Screen.height * 0.5f;

		// Lock cursor to the center of the screen
		Cursor.lockState = CursorLockMode.Confined;

		// Get Rigidbody component
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false; // Assuming gravity isn't needed for the spaceship

		// Set camera position (relative to the spaceship)
		if (cameraTransform == null)
		{
			cameraTransform = Camera.main.transform;
		}
	}

	// Update is called once per frame
	void Update()
	{
		// Get mouse movement relative to screen center
		lookInput.x = Input.mousePosition.x;
		lookInput.y = Input.mousePosition.y;

		mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
		mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

		// Clamp mouse movement to avoid excessive rotation
		mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

		// Handle roll input
		rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

		// Apply the mouse movement to rotate the spaceship
		transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
	}

	// FixedUpdate is used for physics-based movement
	void FixedUpdate()
	{
		// Adjust forward, strafe, and hover speed based on input
		activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
		activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
		activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

		// Apply movement forces in world space
		Vector3 forwardMovement = transform.forward * activeForwardSpeed;
		Vector3 strafeMovement = transform.right * activeStrafeSpeed;
		Vector3 hoverMovement = transform.up * activeHoverSpeed;

		// Set the velocity directly on the Rigidbody for smooth movement
		rb.velocity = forwardMovement + strafeMovement + hoverMovement;

		// Move the camera with the spaceship (smooth follow)
		if (cameraTransform != null)
		{
			Vector3 targetPosition = transform.position + cameraOffset;
			cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
			cameraTransform.LookAt(transform.position); // Keep the camera looking at the spaceship
		}
	}
}
