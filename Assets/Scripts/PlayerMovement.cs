using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Camera camera;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool moveLeft = false;
    private bool moveRight = false;
    private float playerStartingZ;

    // Start is called before the first frame update
    void Start()
    {
        playerStartingZ = rb.position.z;
    }

    void Update() {
        moveLeft = Input.GetKey("a");
        moveRight = Input.GetKey("d");
        // camera.transform.position = 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<GameManager>().gameStarted) {
            forwardForce = forwardForce + (rb.position.z - playerStartingZ);
            playerStartingZ = rb.position.z;
            var ff = forwardForce > 7000f ? 7000f : forwardForce;
            rb.AddForce(0, 0, ff * Time.deltaTime);

            if (moveRight) {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (moveLeft) {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (rb.position.y < -1f) {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
