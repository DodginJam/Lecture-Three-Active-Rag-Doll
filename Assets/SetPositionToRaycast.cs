using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionToRaycast : MonoBehaviour
{
    [field: SerializeField] 
    public float StrideLength
    { get; private set; } = 2.25f;

    [field: SerializeField]
    public Transform NorthTargetPredicted
    { get; private set; }

    [field: SerializeField]
    public Transform SouthTargetPredicted
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
        RaycastHit hitNorth;
        RaycastHit hitSouth;

        bool northHitFound = Physics.Raycast(NorthTargetPredicted.position + transform.up.normalized, -transform.up, out hitNorth);
        bool southHitFound = Physics.Raycast(SouthTargetPredicted.position + transform.up.normalized, -transform.up, out hitSouth);


        if (northHitFound)
        {
            NorthTargetPredicted.position = new Vector3(NorthTargetPredicted.position.x, hitNorth.point.y, NorthTargetPredicted.position.z);
        }

        if (southHitFound)
        {
            SouthTargetPredicted.position = new Vector3(SouthTargetPredicted.position.x, hitSouth.point.y, SouthTargetPredicted.position.z);
        }

        float northDistance = Vector3.Distance(EndEffectorTarget.position, NorthTargetPredicted.position);
        float southDistance = Vector3.Distance(EndEffectorTarget.position, SouthTargetPredicted.position);

        if (northDistance > StrideLength)
        {
            if (Vector3.Distance(EndEffectorTarget.position, SouthTargetPredicted.position) > Vector3.Distance(EndEffectorTarget.position, SouthTargetPredicted.position))
            {
            }
            else if (Vector3.Distance(EndEffectorTarget.position, NorthTargetPredicted.position) > Vector3.Distance(EndEffectorTarget.position, NorthTargetPredicted.position))
            {
            }
        }
        else if (southDistance > StrideLength)
        {

        }
    }
}
