using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 25f;
    [SerializeField] private float gravityModifier = 5f;
    [SerializeField] private int maxLives = 3;
    public int currentLives; // Текущее количество жизней
    [SerializeField] bool isOnGround = true;
    public bool isGameOver = false;
    private Animator playerAnim;

    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _dirtParticle;

    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;
    private AudioSource _audioSoure;

    private UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSoure = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        
        currentLives = maxLives; // Устанавливаем начальное количество жизней
        uiManager.UpdateLives(currentLives); // Обновляем отображение жизней в UI

    }

    // Update is called once per frame
    public void OnJump()
    {

        if (isOnGround && !isGameOver)
        { 
            _audioSoure.PlayOneShot(_jumpSound, 1.0f);
            _dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            uiManager.AddScore(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            _dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            HandleCollisionWithObstacle();
        }
    }

    private void HandleCollisionWithObstacle()
    {
        currentLives--; // Уменьшаем количество жизней

        if (currentLives <= 0)
        {
            // Если жизней больше нет, завершаем игру
            uiManager.UpdateLives(0); // Обновляем отображение жизней
            isGameOver = true;
            _audioSoure.PlayOneShot(_crashSound, 1.0f);
            _dirtParticle.Stop();
            _explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            uiManager.ShowGameOverUI(); // Показать окно "Game Over"
        }
        else
        {
            uiManager.UpdateLives(currentLives); // Обновляем отображение жизней
        }
    }
}
