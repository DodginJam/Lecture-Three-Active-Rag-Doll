using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    [field: SerializeField]
    public bool LegMoving 
    { get; private set; } = false;

    [field: SerializeField]
    public AnimationCurve LerpCurve
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

        if (targetToPredictedStepDistance > StrideLength && LegMoving == false)
        {
            StartCoroutine(TransitionLegs());

            // EndEffectorTarget.position = TargetPredicted.position;
        }
    }

    public IEnumerator TransitionLegs()
    {
        LegMoving = true;

        Vector3 startPosition = EndEffectorTarget.position;
        Vector3 endPosition = TargetPredicted.position;

        float timeToMoveLeg = 0.2f;
        float timeElasped = 0.0f;

        while (timeElasped < timeToMoveLeg)
        {
            float currentTime = timeElasped / timeToMoveLeg;

            Vector3 currentValue = Vector3.Lerp(startPosition, endPosition, currentTime);

            //currentValue = new Vector3(currentValue.x, LerpCurve.Evaluate(currentTime * currentValue.y * 500), currentValue.z);

            EndEffectorTarget.position = currentValue;

            timeElasped += Time.deltaTime;

            if (currentTime > 0.99f)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        LegMoving = false;
    }
}
