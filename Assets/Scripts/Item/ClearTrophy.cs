using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrophy : MonoBehaviour
{
    public GameObject gameClearUI;
    private bool isCleared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCleared) return; // �̹� Ŭ����Ǿ��ٸ� �ߺ� ���� ����

        if (other.CompareTag("Player"))
        {
            GameClear();
            isCleared = true;
        }
    }

    private void GameClear()
    {
        // TimeScale�� 0���� �����Ͽ� ������ ����
        Time.timeScale = 0f;

        if (gameClearUI != null)
        {
            gameClearUI.SetActive(true);
        }
        else
        {
            Debug.LogError("���� Ŭ���� UI ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }
}
