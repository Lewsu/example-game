using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] float jumpForce = 7f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Collision
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform1"))
        {
            Debug.Log("You are on the first block");
        }
        else if (collision.gameObject.CompareTag("Platform2"))
        {
            Debug.Log("You are on the second block");
        }
        else if (collision.gameObject.CompareTag("Platform3"))
        {
            Debug.Log("You are on the third block");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime * movementSpeed);

        // Rotate
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * Time.deltaTime * rotationSpeed);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
