using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraColliderCOPY : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 pos;
    public float smoothSpeed;
    //camera collider? i 'ardly know 'er!
    private void LateUpdate()
    {
        Vector3 MoveTo = playerTransform.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, MoveTo, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
