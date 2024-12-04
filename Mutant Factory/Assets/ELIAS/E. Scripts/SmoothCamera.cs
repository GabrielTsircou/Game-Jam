using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        Vector3 desierdPositiion = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desierdPositiion, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition; 
    }
}
    
   
