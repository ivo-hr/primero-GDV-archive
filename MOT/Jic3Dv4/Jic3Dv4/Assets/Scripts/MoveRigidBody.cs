using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidBody : MonoBehaviour
{
    [SerializeField]
    private float Force = 2f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        
        if(body==null || body.isKinematic)
        {
            return;
        }

        if(hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 Dir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = Dir * Force;
    }
}
