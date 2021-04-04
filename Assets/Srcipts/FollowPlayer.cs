// Written by Mahlet Asmare
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    //smooth speed always between 0 $ 1
    public float smoothSpeed = 0.125f;
    // lateUpdate is same as update but, "right after"
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
       

    }
}