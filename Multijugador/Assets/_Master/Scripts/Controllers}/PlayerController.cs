using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float fuerzaSalto = 10.0f;
    private bool enElSuelo = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 velocidad = rb.velocity;
        velocidad.x = movimientoHorizontal * velocidadMovimiento;
        rb.velocity = velocidad;

        // Salto
        if (enElSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enElSuelo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }
}