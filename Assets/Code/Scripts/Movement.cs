using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {

    [SerializeField] private float speed = 5f;
    [SerializeField] private float tiltSensitivity = 2f;

    private Rigidbody rb;
    private bool canMove = false;
    private bool hasCollided = false;

    private InputAction moveAction;


    private void Start() {
        InputSystem.EnableDevice(Accelerometer.current);
        //moveAction = InputSystem.actions.FindAction("MoveCube");
        //Debug.Log(moveAction.name);
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 2f;
        rb.useGravity = false;
        Invoke("EnableGravity", 1f); 
    }

    private void EnableGravity() {
        rb.useGravity = true;
        canMove = true;
    }

    private void FixedUpdate() {

        var acceleration = Accelerometer.current.acceleration.ReadValue();
        if (canMove) {
            float moveX = acceleration.x * tiltSensitivity;
            rb.linearVelocity = new Vector3(moveX * speed, rb.linearVelocity.y, 0);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (!hasCollided) {
            hasCollided = true;
            canMove = false;
            if (collision.gameObject.CompareTag("Cube")) {
                SpawnGenerator._instance.UpdateScore();
            }
            SpawnGenerator._instance.spawnCube();
        }
    }
}
