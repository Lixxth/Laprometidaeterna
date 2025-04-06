using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaraMovimiento : MonoBehaviour
{

    public Transform target; // El objeto al que la cámara seguirá
    public float smoothSpeed; // La velocidad de suavizados
    public Vector2 maxPosition; // La posición máxima de la cámara
    public Vector2 minPosition; // La posición mínima de la cámara



    void Start(){

    }

    void LateUpdate(){
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Limitar la posición de la cámara
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
