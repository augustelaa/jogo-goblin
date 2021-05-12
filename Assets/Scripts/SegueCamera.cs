using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueCamera : MonoBehaviour
{
    public Transform TargetObject;
    public float followDistance = 5f;
    public float followHeight = 2f;
    public bool smoothedFollow = false;
    public float smoothSpeed = 5f;
    public bool useFixedLookDirection = false;
    public Vector3 fixedLookDirection = Vector3.one;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        //get a vector pointing from camera towards the ball

        Vector3 lookToward = TargetObject.position - transform.position;
        if(useFixedLookDirection )
                lookToward  = fixedLookDirection ;


        //make it stay a fixed distance behind ball
        Vector3 newPos;
        newPos =  TargetObject.position - lookToward.normalized * followDistance;
        newPos.y = TargetObject.position.y + followHeight ;

        if (!smoothedFollow)
        {
            transform.position = newPos;    //move exactly to follow target
        }
        else   //  smoothed / soft follow
        {
            transform.position += (newPos - transform.position) * Time.deltaTime * smoothSpeed;
        }

        //re- calculate look direction (dont' do this line if you want to lag the look a little
        lookToward = TargetObject.position - transform.position;

        //make this camera look at target
        transform.forward = lookToward.normalized;
    }
}