using UnityEngine;

public class MarioController : MonoBehaviour
{
    private IMovement movement;

    // Ссылка на объект groundCheck
    public Transform groundCheck;
    //public string groundCheckName = "GroundCheck"

    private void Start()
    {

        groundCheck = transform.GetChild(0);
        // Создание экземпляра MarioMovement и передача ему ссылки на Rigidbody2D и groundCheck
        movement = new MarioMovement(this.GetComponent<Rigidbody2D>(), groundCheck);
    }

    private void Update()
    {
        // Обработка ввода для перемещения Марио
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movement.Move(horizontalInput);

        // Прыжок Марио
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }
    }
}

public class MarioMovement : IMovement
{
    private Rigidbody2D rb;
    private Transform groundCheck; // Ссылка на объект groundCheck
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    // Конструктор класса MarioMovement принимает Rigidbody2D и Transform groundCheck
    public MarioMovement(Rigidbody2D rb, Transform groundCheck)
    {
        this.rb = rb;
        this.groundCheck = groundCheck;
        groundLayer = LayerMask.GetMask("Ground");
    }

    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}

public interface IMovement
{
    void Move(float direction);
    void Jump();
}
