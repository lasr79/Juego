using UnityEngine;
using UnityEngine.SceneManagement; 
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true; // Asumo que empieza mirando a la derecha

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        // Game over si cae demasiado
        if (transform.position.y < -10f)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
    }

    void Flip()
    {
        facingRight = !facingRight; // Cambia la dirección
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale; // Aplica el volteo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
        if(collision.gameObject.CompareTag("EnemyFire"))
            Die();
        if(collision.gameObject.CompareTag("Meta"))  
            Win();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
     void Die(){
    Debug.Log("El jugador se ha muerto");
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     void Win(){
    Debug.Log("Has ganado");
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
} 
