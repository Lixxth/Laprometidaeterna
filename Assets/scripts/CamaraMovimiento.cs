using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaraMovimiento : MonoBehaviour
{

    public Transform target; // El objeto al que la c�mara seguir�
    public float smoothSpeed; // La velocidad de suavizados
    public Vector2 maxPosition; // La posici�n m�xima de la c�mara
    public Vector2 minPosition; // La posici�n m�nima de la c�mara



    void Start(){

    }

    void LateUpdate(){
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Limitar la posici�n de la c�mara
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
