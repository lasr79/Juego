using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escenas

public class MenuController : MonoBehaviour
{
    // Método para cargar el Escenario 1
    public void CargarEscenario1()
    {
        Debug.Log("🚀 Cargando Escenario 1...");
        SceneManager.LoadScene("Escenario1"); // Asegúrate que el nombre coincida exactamente con tu escena
    }

    // Método para cargar el Escenario 2
    public void CargarEscenario2()
    {
        Debug.Log("🚀 Cargando Escenario 2...");
        SceneManager.LoadScene("Escenario2");
    }

    // Método para cargar el Escenario 3
    public void CargarEscenario3()
    {
        Debug.Log("🚀 Cargando Escenario 3...");
        SceneManager.LoadScene("Escenario3");
    }

    
}
