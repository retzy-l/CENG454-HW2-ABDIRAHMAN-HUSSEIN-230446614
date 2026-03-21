// FlightController.cs
// CENG 454 - HW1: Sky-High Prototype
// Author: ABDIRAHMAN HUSSEIN | Student ID: 230446614

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitch = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitch * pitchSpeed * Time.deltaTime);
        float yaw = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yaw * yawSpeed * Time.deltaTime);
        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll = 1f;
        if (Input.GetKey(KeyCode.E)) roll = -1f;
        transform.Rotate(Vector3.forward * roll * rollSpeed * Time.deltaTime);
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}
