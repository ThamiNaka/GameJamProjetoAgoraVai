using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;
    public float xOffset = 5f;
    public float yOffset = 5f;

    private void LateUpdate()
    {
        if (target)
        {
            float targetX = target.position.x + xOffset;
            float targetY = target.position.y + yOffset;
            float currentX = Mathf.Lerp(transform.position.x, targetX, smoothSpeed * Time.deltaTime);
            float currentY = Mathf.Lerp(transform.position.y, targetY, smoothSpeed * Time.deltaTime);
            Vector3 newPosition = new Vector3(currentX, currentY, transform.position.z);
            transform.position = newPosition;
        }
    }
}