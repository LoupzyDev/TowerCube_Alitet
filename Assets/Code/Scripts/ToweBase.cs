using UnityEngine;
using UnityEngine.SceneManagement;

public class ToweBase : MonoBehaviour
{
    private bool isFirstCube = true;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Floor")) {
            SceneManager.LoadScene("BlockLevel");
        }
        if (collision.gameObject.CompareTag("Cube")) {
            if (isFirstCube) {
                SpawnGenerator._instance.UpdateScore();
                isFirstCube = false;
            }
        }
    }
}
