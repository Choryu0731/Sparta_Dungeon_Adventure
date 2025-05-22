using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseSystem : MonoBehaviour
{
    private PlayerController player;

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    public void Use(ItemData item)
    {
        if (item == null) return;

        switch (item.itemType)
        {
            case ItemType.DoubleJump:
                StartCoroutine(ApplyDoubleJump(item.duration));
                break;
            case ItemType.SpeedBoost:
                StartCoroutine(ApplySpeedBoost(item.duration));
                break;
            case ItemType.Invincibility:
                StartCoroutine(ApplyInvincibility(item.duration));
                break;
        }
    }

    IEnumerator ApplyDoubleJump(float duration)
    {
        player.allowDoubleJump = true;
        yield return new WaitForSeconds(duration);
        player.allowDoubleJump = false;
    }

    IEnumerator ApplySpeedBoost(float duration)
    {
        float originSpeed = player.moveSpeed;
        player.moveSpeed *= 1.5f;
        yield return new WaitForSeconds(duration);
        player.moveSpeed = originSpeed;
    }

    IEnumerator ApplyInvincibility(float duration)
    {
        player.isInvincible = true;
        yield return new WaitForSeconds(duration);
        player.isInvincible = false;
    }
}