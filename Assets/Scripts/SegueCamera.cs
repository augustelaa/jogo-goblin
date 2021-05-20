using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueCamera : MonoBehaviour
{
    public Transform TargetObject;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 novaPosicao = new Vector3(TargetObject.position.x, TargetObject.position.y, TargetObject.position.z - 8f);
        transform.position = Vector3.Lerp(transform.position, novaPosicao, 2f * Time.deltaTime);
    }
}