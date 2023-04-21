using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public AudioClip endSound;
    AudioSource audioSource;    // 获取音源组件
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnEndButton()
    {
        // 播放音效
        audioSource.clip = endSound;
        audioSource.Play();

        // 开启携程
        StartCoroutine(CoGameEnd());
    }

    IEnumerator CoGameEnd()
    {
        GameObject btn = GameObject.Find("结束按钮");
        // 开始按钮闪烁
        for (int i = 0; i < 6; i++)
        {
            // 隐藏-> 显示    显示-> 隐藏
            btn.SetActive(!btn.activeInHierarchy);
            yield return new WaitForSeconds(0.3f);
        }

        // 切换场景
        Debug.Log("切换场景");

        // 加载游戏场景
        SceneManager.LoadScene("Game");

    }
}
