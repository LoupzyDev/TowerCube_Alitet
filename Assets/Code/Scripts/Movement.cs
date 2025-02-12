using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float tiltSensitivity = 2f;
    private bool canMove = false;
    private bool hasCollided = false;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 2f;
        rb.useGravity = false;
        Invoke("EnableGravity", 1f); 
    }

    private void EnableGravity() {
        rb.useGravity = true;
        canMove = true;
    }

    private void Update() {
        if (canMove) {
            Vector3 tilt = Input.acceleration; // Captura la inclinación del teléfono
            float moveX = tilt.x * tiltSensitivity; // Usa la inclinación en X

            rb.linearVelocity = new Vector3(moveX * speed, rb.linearVelocity.y, 0);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!hasCollided) {
            hasCollided = true;
            canMove = false;
            SpawnGenerator._instance.spawnCube();
        }
    }
}
