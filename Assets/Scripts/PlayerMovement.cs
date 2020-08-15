using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rayCatsDistance = 1f;

    Rigidbody rb;

    Vector3 input;
    Camera cachedCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cachedCamera = Camera.main;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        input.x = x;
        input.z = y;

        Ray ray = cachedCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, rayCatsDistance))
        {
            Debug.Log("Ray hitted with: " + hit.collider.gameObject.name);
        }
        Debug.DrawRay(ray.origin, ray.direction * rayCatsDistance, Color.red);
    }

    private void FixedUpdate()
    {
        Vector3 velocity = input.normalized * speed;
        rb.velocity = velocity;
    }

    private int GetIn()
    {
        int n = 1;
        return n;
    }
}
