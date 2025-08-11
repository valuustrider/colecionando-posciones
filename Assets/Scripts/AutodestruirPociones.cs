using UnityEngine;

public class AutordestruirPociones : MonoBehaviour
{
    void Start()
    {
        // Inicia la corrutina que destruirá el objeto después de un tiempo aleatorio
        StartCoroutine(CronometroPociones());
    }

    private System.Collections.IEnumerator CronometroPociones()
    {
        // Obtén un número aleatorio entre 1 y 5
        float espera = Random.Range(1f, 5f);

        // Espera ese tiempo
        yield return new WaitForSeconds(espera);

        // Destruye el objeto
        Destroy(gameObject);
    }
}
