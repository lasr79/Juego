using UnityEngine;
using UnityEngine.SceneManagement; 
<<<<<<< HEAD

public class PlayerController : MonoBehaviour
{ 
=======
public class PlayerController : MonoBehaviour
{
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
<<<<<<< HEAD
    private bool facingRight = true;

    public Vector3 puntoInicial; // Punto donde reaparecerá el jugador
=======
    private bool facingRight = true; // Asumo que empieza mirando a la derecha
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        puntoInicial = transform.position; // Guarda la posición inicial del jugador
=======
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
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
<<<<<<< HEAD

        // 🔥 Si cae al vacío, perder vida y reaparecer
        if (transform.position.y < -10f)
        {
            Debug.Log("⛔ El jugador ha caído al vacío");
            Die(); 
=======
        // Game over si cae demasiado
        if (transform.position.y < -10f)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
        } 
    }

    void Flip()
    {
<<<<<<< HEAD
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
=======
        facingRight = !facingRight; // Cambia la dirección
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale; // Aplica el volteo
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< HEAD
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("🔥 ¡Colisión con enemigo detectada!");
            Die();
        }

        if (collision.gameObject.CompareTag("Meta"))  
        {
            Win1();
        }
        if (collision.gameObject.CompareTag("Meta2"))  
        { 
            Win2();
         }   
        if (collision.gameObject.CompareTag("MetaFinal"))  
        {
            WinF();
        }
=======
        Debug.Log("Colisión detectada con: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
        if(collision.gameObject.CompareTag("EnemyFire"))
            Die();
        if(collision.gameObject.CompareTag("Meta"))  
            Win();
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
<<<<<<< HEAD

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

    void Win1()
    {
        Debug.Log("🏆 ¡Has ganado!");
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    
               Destroy(gameManager.gameObject); // Destruye el GameManager antes de cambiar la escena
               
               SceneManager.LoadScene("Escenario3");
    }
     void Win2()
    {
        Debug.Log("🏆 ¡Has ganado!");
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    
               Destroy(gameManager.gameObject); // Destruye el GameManager antes de cambiar la escena
               
               SceneManager.LoadScene("Escenario3");
    }
       void WinF()
    {
        Debug.Log("🏆 ¡Has ganado!");
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    
               Destroy(gameManager.gameObject); // Destruye el GameManager antes de cambiar la escena
               
               SceneManager.LoadScene("Winner");
    }
}

=======
     void Die(){
    Debug.Log("El jugador se ha muerto");
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     void Win(){
    Debug.Log("Has ganado");
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
} 
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
