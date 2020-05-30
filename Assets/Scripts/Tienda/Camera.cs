using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject pivot;
    [SerializeField]
    private float positionRecta;

    // Update is called once per frame
    void Update()
    {/*
        Vector3 vectorDireccion = pivot.transform.position-transform.position;


        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            positionRecta += 0.00000000001f;
            transform.Translate(pivot.transform.position + positionRecta*(vectorDireccion));
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            positionRecta-= 0.00000000001f;
            transform.Translate(pivot.transform.position + positionRecta*(vectorDireccion));
        }

        Debug.Log(vectorDireccion);*/
    }
}
