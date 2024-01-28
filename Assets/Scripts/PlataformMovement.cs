using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovement : MonoBehaviour
{
    public Transform plataform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1f;
    int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        plataform.position = Vector2.Lerp(plataform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)plataform.position).magnitude;

        if ( distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if(plataform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(plataform.transform.position, startPoint.position);
            Gizmos.DrawLine(plataform.transform.position, endPoint.position);
        }
    }

}
