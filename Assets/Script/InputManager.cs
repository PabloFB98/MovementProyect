using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform cubeTransform;

    public float speed = 3;
    public float rotationSpeed = 100;
    public float jumpForce = 5;

    public Rigidbody rb;

    private bool isGrounded = true;

    void Start()
    {

    }

    void Update()
    {
        /*
        Debug.DrawRay(cubeTransform.position, Vector3.right * Input.GetAxis("Horizontal"), Color.red);
        Debug.DrawRay(cubeTransform.position, Vector3.forward * Input.GetAxis("Vertical"), Color.blue);
        print("Horizontal: " + Input.GetAxis("Horizontal"));
        print("Vertical: " + Input.GetAxis("Vertical"));
        */

        // Movimiento con el ratón
        cubeTransform.Translate(Vector3.right * Input.GetAxis("Mouse X") * Time.deltaTime * speed * 5);
        cubeTransform.Translate(Vector3.forward * Input.GetAxis("Mouse Y") * Time.deltaTime * speed * 5);

        // Movimiento con teclado
        cubeTransform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        cubeTransform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

        // Rotación
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                jumpForce,
                rb.linearVelocity.z
            );

            isGrounded = false;
        }
    }

    // Detectar cuando toca el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
