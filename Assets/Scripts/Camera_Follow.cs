using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
public Transform TargetToFollow;
public Transform TargetToLook;
public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.Lerp(transform.position,TargetToFollow.position,Speed*Time.deltaTime);      //Lerp Interpola entre dos posiciones.
        transform.LookAt(TargetToLook);
    }
}
