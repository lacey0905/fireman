using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject followTarget;
    public float cameraSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, cameraSpeed * Time.fixedDeltaTime);
    }

}
