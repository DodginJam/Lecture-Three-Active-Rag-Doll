using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float VerticalInput
    { get; private set; }

    [field: SerializeField] public float Speed
    { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");

        gameObject.transform.position += Time.deltaTime * Speed * VerticalInput * gameObject.transform.forward;
    }
}
