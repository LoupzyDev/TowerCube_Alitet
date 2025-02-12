using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
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
            float moveX = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveX * speed, rb.linearVelocity.y, 0);
            rb.linearVelocity = movement;
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
