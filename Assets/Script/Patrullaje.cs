using UnityEngine;

public class Patrullar : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Vector3 destino;

    void Start()
    {
        destino = puntoB.position;
    }

    void Update()
    {
        // Mostrar distancia en consola para verificar el comportamiento
        Debug.Log("Distancia al destino: " + Vector3.Distance(transform.position, destino));

        // Mover hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        // Si llega al destino, cambia de dirección
        if (Vector3.Distance(transform.position, destino) < 1.5f)
        {
            Debug.Log("¡Llegó al punto!");
            Flip();
            destino = (destino == puntoA.position) ? puntoB.position : puntoA.position;
        }
    }

    void Flip()
    {
        // Gira solo si el personaje está orientado de forma incorrecta
        if ((destino == puntoA.position && transform.localScale.x < 0) || 
            (destino == puntoB.position && transform.localScale.x > 0))
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
