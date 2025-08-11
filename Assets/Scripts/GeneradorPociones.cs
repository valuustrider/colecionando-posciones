using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject pocion; 
    public Camera camaraPrincipal; 
    public float minEspera = 0.5f;
    public float maxEsperar = 3f;

    void Start()
    {
        if (camaraPrincipal == null)
        {
            camaraPrincipal = Camera.main;
        }

        StartCoroutine(cicloPosion());
    }

    IEnumerator cicloPosion()
    {
        while (true)
        {
            float esperar = Random.Range(minEspera, maxEsperar);
            yield return new WaitForSeconds(esperar);

            Vector3 aparecerPosicion = ObtenerPosicion();
            Instantiate(pocion, aparecerPosicion, Quaternion.identity);
        }
    }

    Vector3 ObtenerPosicion()
    {
        float zDistancia = Mathf.Abs(camaraPrincipal.transform.position.z); // Distancia desde la cámara

        // Elegimos una posición aleatoria en la pantalla
        Vector2 pantallaPosicion = new Vector2(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );

        // Convertimos la posición de pantalla a posición del mundo
        Vector3 mundoPosicion = camaraPrincipal.ViewportToWorldPoint(new Vector3(pantallaPosicion.x, pantallaPosicion.y, zDistancia));

        return mundoPosicion;
    }
}
