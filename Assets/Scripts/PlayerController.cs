using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;


    public List<Sprite> idles = new List<Sprite>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener el input del jugador
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Debug.Log(movement.sqrMagnitude + "el movimiento o speed");

        // Normalizar el vector de movimiento para evitar movimientos diagonales más rápidos
        movement = new Vector2(moveX, moveY).normalized;

    }

    void FixedUpdate()
    {
        // Mover al jugador basado en el vector de movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }

}
