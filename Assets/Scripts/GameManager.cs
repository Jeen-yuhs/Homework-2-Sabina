using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private BobController _bobController; //ссылка на боба которая сообщает о смерти в методе MakeDamage, срабатывет эвент OnKilled?.Invoke(), на которое подписываемся в GameManager
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;

    private void OnEnable()
    {
        _bobController.OnKilled += BobControllerOnKilled; //подписка на эвент - GM слушаем когда случится смерть Боба
    }

    private void OnDisable()
    {
        _bobController.OnKilled -= BobControllerOnKilled; //отписка
    }

    private void BobControllerOnKilled() //когда Боб умирает всплывает экран "Container" (GameOver) И две кнопки
    {
        _endScreen.SetActive(true);
    }

    //метод-1
    //public void Restart() //функционал кнопки RESTART
    //{
    //    SceneManager.LoadScene(1);
    //}

    //public void Exit() //функционал кнопки BACK
    //{
    //    SceneManager.LoadScene(0);
    //}

    //метод-2
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
