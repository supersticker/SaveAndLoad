using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float moveSpeed = 10f;
    float actualSpeed;

    Vector2 moveInput;
    private void Start()
    {
        actualSpeed = moveSpeed;
    }
    public void OnMove(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
    }

    private void Update()
    {
        actualSpeed = Mathf.MoveTowards(actualSpeed, moveSpeed, Time.deltaTime * 2);
    }

    void FixedUpdate()
    {
        playerRb.linearVelocity = moveInput * actualSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.AddScore();
            actualSpeed += 2f;

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Door"))
        {
            GameManager.LoadNextLevel();
        }
    }
}