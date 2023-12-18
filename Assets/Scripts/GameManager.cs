using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private BobController _bobController; //������ �� ���� ������� �������� � ������ � ������ MakeDamage, ���������� ����� OnKilled?.Invoke(), �� ������� ������������� � GameManager
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;

    private void OnEnable()
    {
        _bobController.OnKilled += BobControllerOnKilled; //�������� �� ����� - GM ������� ����� �������� ������ ����
    }

    private void OnDisable()
    {
        _bobController.OnKilled -= BobControllerOnKilled; //�������
    }

    private void BobControllerOnKilled() //����� ��� ������� ��������� ����� "Container" (GameOver) � ��� ������
    {
        _endScreen.SetActive(true);
    }

    //�����-1
    //public void Restart() //���������� ������ RESTART
    //{
    //    SceneManager.LoadScene(1);
    //}

    //public void Exit() //���������� ������ BACK
    //{
    //    SceneManager.LoadScene(0);
    //}

    //�����-2
    public void LoadScreen(int sceneNumber)
    {
      SceneManager.LoadScene(sceneNumber);
    }

    public void LvlCompleted() 
    {  
        _winScreen.SetActive(true);
        _bobController.enabled = false;
    }
}
