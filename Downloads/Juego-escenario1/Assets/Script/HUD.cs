using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas; // Array con todos los iconos de vidas

    public void DesactivarVida(int vidasRestantes)
    {
        Debug.Log("🔵 Actualizando HUD: Vidas restantes = " + vidasRestantes);

        for (int i = 0; i < vidas.Length; i++)
        {
            // ✅ Comprobación adicional para evitar errores
            if (vidas[i] != null)
            {
                vidas[i].SetActive(i < vidasRestantes);
            }
        }
    }
}
