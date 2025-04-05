using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPersonaje : MonoBehaviour {
    //variable que tan rapido se mueven los jugadores
    public float velocidad;
    //variable que almacena el componente Rigidbody2D
    private Rigidbody2D myrb;
    //vector que almacena la direccion del movimiento
    private Vector3 mov;
    //variable que almacena el componente Animator
    private Animator animator;



    //use this for initialization
    void Start()  {
        animator = GetComponent<Animator>();
        myrb = GetComponent<Rigidbody2D>();


    }
     void Update() {
        //se obtiene la direccion del movimiento
        mov = Vector3.zero;
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove ()
    {
        if (mov != Vector3.zero)
        {
            MoveCharacter();
            //se asigna la animacion de caminar
            animator.SetFloat("MovimientoX", mov.x);
            animator.SetFloat("MovimientoY", mov.y);
            animator.SetBool("Movimiento", true); // esto es para que el personaje camine
        }
        else
        {
            //se asigna la animacion de idle
            animator.SetBool("Movimiento", false); // esto es para que el personaje no camine
        }
    }

    void MoveCharacter()
    {
        myrb.MovePosition(
           transform.position + mov * velocidad * Time.deltaTime
            );
    }
}
