using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    private PlayerController playerControllerScript;
    private float leftBound = -15f;

    // Update is called once per frame
    private void Start()
       {
          playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       }

    void Update()
    {
      if (!playerControllerScript.isGameOver)
      {
          transform.Translate(Vector3.left * speed * Time.deltaTime);
      }

       if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }


}


