using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public AudioClip startSound;    // ��ʼ��ť��Ч,ע����AudioClip����AudioSource

    AudioSource audioSource;  // ��ȡ��Դ���
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   
    // ���°�ť�Ժ�
    public void OnStartButton()
    {
        // ������Ч
        audioSource.clip = startSound;
        audioSource.Play();

        // ����Я��
        StartCoroutine(CoGameStart());
    }

    // Я�̺���
    IEnumerator CoGameStart()
    {
        GameObject btn = GameObject.Find("��ʼ��ť");
        // ��ʼ��ť��˸
        for(int i = 0; i < 6; i++)
        {
            // ����-> ��ʾ    ��ʾ-> ����
            btn.SetActive(!btn.activeInHierarchy);
            yield return new WaitForSeconds(0.3f);
        }

        // �л�����
        Debug.Log("�л�����");

        // ������Ϸ����
        SceneManager.LoadScene("Game");






    }
}
