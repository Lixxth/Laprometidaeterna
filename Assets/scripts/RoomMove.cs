using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Aceder a la interfaz de ususario 
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChange; // Cambia la posición de la cámara
    public Vector3 playerChange; // Cambia la posición del jugador
    private CamaraMovimiento cam; // Referencia al script de la cámara
    public bool needText; // Si se necesita un texto
    public string placeName; // Texto que se necesita
    public GameObject text; // Objeto de texto
    public Text placeText; // Texto que se necesita

    void Start()
    {
        // Inicializa el objeto
        cam = Camera.main.GetComponent<CamaraMovimiento>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if (needText)
            {
              StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }

}
