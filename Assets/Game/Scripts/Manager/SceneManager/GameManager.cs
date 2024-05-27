using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Controller;

public class GameManager : RingSingleton<GameManager>
{
    public GameController _gameController;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void Update()
    {
    }

}
