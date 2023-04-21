using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public AudioClip endSound;
    AudioSource audioSource;    // ��ȡ��Դ���
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnEndButton()
    {
        // ������Ч
        audioSource.clip = endSound;
        audioSource.Play();

        // ����Я��
        StartCoroutine(CoGameEnd());
    }

    IEnumerator CoGameEnd()
    {
        GameObject btn = GameObject.Find("������ť");
        // ��ʼ��ť��˸
        for (int i = 0; i < 6; i++)
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
