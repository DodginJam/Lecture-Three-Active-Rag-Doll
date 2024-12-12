using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float VerticalInput
    { get; private set; }
    public float HorizontalInput
    { get; private set; }

    [field: SerializeField] public float MovementSpeed
    { get; private set; }

    [field: SerializeField] public float RotationSpeed
    { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        gameObject.transform.position += Time.deltaTime * MovementSpeed * VerticalInput * gameObject.transform.forward;

        gameObject.transform.rotation *= Quaternion.Euler(Time.deltaTime * RotationSpeed * HorizontalInput * gameObject.transform.up);
    }
}
