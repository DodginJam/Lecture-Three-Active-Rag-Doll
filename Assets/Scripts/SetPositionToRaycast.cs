using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionToRaycast : MonoBehaviour
{
    [field: SerializeField] 
    public float StrideLength
    { get; private set; } = 1.0f;

    [field: SerializeField]
    public Transform TargetPredicted
    { get; private set; }

    [field: SerializeField]
    public Transform EndEffectorTarget
    { get; private set; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        bool hitFound = Physics.Raycast(TargetPredicted.position + transform.up.normalized, -transform.up, out hit);
        Debug.DrawRay(TargetPredicted.position + transform.up.normalized, -transform.up);

        if (hitFound)
        {
            TargetPredicted.position = new Vector3(TargetPredicted.position.x, hit.point.y, TargetPredicted.position.z);
        }

        float targetToPredictedStepDistance = Vector3.Distance(EndEffectorTarget.position, TargetPredicted.position);

        if (targetToPredictedStepDistance > StrideLength)
        {
            EndEffectorTarget.position = TargetPredicted.position;
        }
    }
}
