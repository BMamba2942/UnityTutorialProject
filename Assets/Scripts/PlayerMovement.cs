using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
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
        Vector3 pos = new Vector3(0, 0, 0);
        float breakPoint = 0f;
        if (Input.GetMouseButton(0)) {
            pos = Input.mousePosition;
            breakPoint = Screen.width / 2;
        }
        moveLeft = Input.GetKey("a") || pos.x < breakPoint;
        moveRight = Input.GetKey("d") || pos.x > breakPoint;
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
