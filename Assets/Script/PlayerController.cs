using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{ 
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    public Vector3 puntoInicial; // Punto donde reaparecerá el jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puntoInicial = transform.position; // Guarda la posición inicial del jugador
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

        // 🔥 Si cae al vacío, perder vida y reaparecer
        if (transform.position.y < -10f)
        {
            Debug.Log("⛔ El jugador ha caído al vacío");
            Die(); 
        } 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("🔥 ¡Colisión con enemigo detectada!");
            Die();
        }

        if (collision.gameObject.CompareTag("Meta"))  
            Win();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void Die()
    {
        Debug.Log("💀 El jugador ha muerto");

        if (GameManager.instance != null)
        {
            GameManager.instance.PerderVida();  // 🔥 Primero restar la vida

            if (GameManager.instance.GetVidas() <= 0)
            {
               GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    
               Destroy(gameManager.gameObject); // Destruye el GameManager antes de cambiar la escena
    

                SceneManager.LoadScene("GameOver");  // Reinicia la escena de Game Over
            }
            else
            {
                // 🔥 Reaparece en el punto inicial
                transform.position = puntoInicial;
                Debug.Log("🔄 Reapareciendo en el punto inicial");
            }
        }
        else
        {
            Debug.LogError("❗ El GameManager no se encontró en la escena.");
        }
    }

    void Win()
    {
        Debug.Log("🏆 ¡Has ganado!");
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    
               Destroy(gameManager.gameObject); // Destruye el GameManager antes de cambiar la escena
               
               SceneManager.LoadScene("Escenario3");
    }
}

