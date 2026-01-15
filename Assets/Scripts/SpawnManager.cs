using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private string obstacleTag = "Obstacle"; // Тег для поиска препятствий
    [SerializeField] GameObject[] obstacles;
    private Vector3 spawnPos = new Vector3(25f, 0f, 0f);
    [SerializeField] float startDelay = 2f;
    [SerializeField] float repeatRate = 2f;

    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); 
    }




    // Update is called once per frame
    void SpawnObstacle()
    {
        if (!playerController.isGameOver)
        {
            if (obstacles.Length > 0)
            {
                // Выбираем случайное препятствие
                int randomIndex = Random.Range(0, obstacles.Length);
                GameObject randomObstacle = obstacles[randomIndex];

                Instantiate(randomObstacle, spawnPos, randomObstacle.transform.rotation);
            }
         }
        }
    }

