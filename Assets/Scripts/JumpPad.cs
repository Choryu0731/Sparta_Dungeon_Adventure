using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float superJumpPower = 20f;
    public Vector3 jumpDirection = Vector3.up;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 기존 수직 속도 제거 후, 위로 강한 힘 가하기
                Vector3 velocity = rb.velocity;
                velocity.y = 0f;
                rb.velocity = velocity;

                rb.AddForce(jumpDirection.normalized * superJumpPower, ForceMode.VelocityChange);
            }
        }
    }
}
