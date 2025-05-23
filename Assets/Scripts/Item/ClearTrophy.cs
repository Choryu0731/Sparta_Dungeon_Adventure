using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrophy : MonoBehaviour
{
    public GameObject gameClearUI;
    private bool isCleared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCleared) return; // 이미 클리어되었다면 중복 실행 방지

        if (other.CompareTag("Player"))
        {
            GameClear();
            isCleared = true;
        }
    }

    private void GameClear()
    {
        // TimeScale을 0으로 설정하여 게임을 멈춤
        Time.timeScale = 0f;

        if (gameClearUI != null)
        {
            gameClearUI.SetActive(true);
        }
        else
        {
            Debug.LogError("게임 클리어 UI 오브젝트가 할당되지 않았습니다!");
        }
    }
}
