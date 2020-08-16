using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacle;
    public GameObject ground;
    public Vector3 spawnOffset;
    private System.Random random = new System.Random();
    private float maxZGenerated = -1.0f;

    private void GenerateObjects(int amount, Vector3 playerPosition) {
        for (int i = 0; i < amount; i++) {
            var r = Random.Range(-ground.transform.localScale.x / 2, ground.transform.localScale.x/2);
            Vector3 obstaclePosition = new Vector3(r, playerPosition.y, playerPosition.z + (spawnOffset.z * (i+1)));
            GameObject newObstacle = Object.Instantiate(obstacle);
            newObstacle.transform.position = obstaclePosition;
            maxZGenerated = maxZGenerated < obstaclePosition.z ? obstaclePosition.z : maxZGenerated;
        }
    }

    void Start() {
        GenerateObjects(498, player.transform.position);
    }
}
