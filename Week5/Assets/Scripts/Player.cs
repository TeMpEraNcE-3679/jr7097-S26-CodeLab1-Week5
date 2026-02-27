using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    
    Rigidbody rb;

    public float forceAmount;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyUp))
        {
            rb.AddForce(Vector3.up*forceAmount);
        }

        if (Input.GetKey(keyDown))
        {
            rb.AddForce(Vector3.down*forceAmount);
        }

        if (Input.GetKey(keyLeft))
        {
            rb.AddForce(Vector3.left*forceAmount);
        }

        if (Input.GetKey(keyRight))
        {
            rb.AddForce(Vector3.right*forceAmount);
        }
    }
}
