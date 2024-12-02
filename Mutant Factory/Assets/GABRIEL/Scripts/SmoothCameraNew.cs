using UnityEngine;

public class SmoothCameraNew : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public Transform barrierTransform;

    private void LateUpdate()
    {
        Vector3 desierdPositiion = playerTransform.position + offset; //follows player, accounts for offset
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desierdPositiion, smoothSpeed * Time.deltaTime); //the fuck is lerp
        transform.position = smoothedPosition; //sets final smooth position as camera position
        if ((smoothedPosition == barrierTransform)
        {

        }
    }
}