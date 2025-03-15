using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el GameManager se destruya entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public HUD hud;
    public Renderer fondo;

    private int vidas = 3;

    void Update()
    {
        fondo.material.mainTextureOffset += new Vector2(0.015f, 0) * Time.deltaTime;
    }

    public void PerderVida()
    {
        vidas--;

        Debug.Log("⚠️ Vidas restantes: " + vidas);

        if (hud != null)
        {
            hud.DesactivarVida(vidas);  // ✅ Actualizar el HUD cada vez que se pierde una vida
        }
        else
        {
            Debug.LogError("❗ Error: HUD no está asignado en el GameManager.");
        }

        if (vidas <= 0)
        {
            Debug.Log("🚨 Se acabaron las vidas, cargando escena de Game Over.");
            SceneManager.LoadScene("GameOver");
        }
    }

    public int GetVidas()
    {
        return vidas;
    }
}
=======

public class GameManager : MonoBehaviour
{

    public Renderer fondo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;


    }
}
>>>>>>> 223c32bd049fcc5127d06bd6f1d706fa9fa28285
