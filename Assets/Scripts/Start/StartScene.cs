using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public AudioClip startSound;    // 开始按钮音效,注意是AudioClip不是AudioSource

    AudioSource audioSource;  // 获取音源组件
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   
    // 按下按钮以后
    public void OnStartButton()
    {
        // 播放音效
        audioSource.clip = startSound;
        audioSource.Play();

        // 开启携程
        StartCoroutine(CoGameStart());
    }

    // 携程函数
    IEnumerator CoGameStart()
    {
        GameObject btn = GameObject.Find("开始按钮");
        // 开始按钮闪烁
        for(int i = 0; i < 6; i++)
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
