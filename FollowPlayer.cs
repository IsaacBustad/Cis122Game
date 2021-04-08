// Written by Mahlet Asmare
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    //smooth speed always between 0 $ 1
    public float smoothSpeed = 0.125f;
    // lateUpdate is same as update but, "right after"
    /*void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);

    }*/
    void LateUpdate()
    {
        if (transform.position!= player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}