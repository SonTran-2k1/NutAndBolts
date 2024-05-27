using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ring;

namespace Controller
{
    #region Component

    [Serializable]
    public class GameController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Game Controller")] [ChangeColorLabel(0.2f, 1, 1)]
        public GameObject _player;
    }

    [Serializable]
    public class PlayerController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Player Controller")] [ChangeColorLabel(0.2f, 1, 1)]
        public Rigidbody _rigidbodyWeapon;
    }

    [Serializable]
    public class BotController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Bot Controller")] [ChangeColorLabel(0.2f, 1, 1)]
        public Rigidbody _rigidbodyBot;
    }

    [Serializable]
    public class MusicController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Audio Clip")] [ChangeColorLabel(0.9f, .55f, .95f)]
        public AudioClip audioClip_;

        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Audio Source")] [ChangeColorLabel(0.2f, 1, 1)]
        public AudioSource audioSource_;
    }

    [Serializable]
    public class UiController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Ui Controller")] [ChangeColorLabel(0.2f, 1, 1)]
        public GameObject _winGameObject;
    }

    [Serializable]
    public class CheckScene
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Check Scene")] [ChangeColorLabel(.7f, 1f, 1f)]
        public bool _isGetCurrentNameScene;

        [ChangeColorLabel(.7f, 1f, 1f)] public string _nameSceneChange;
    }

    #endregion Component
}

#region Base Method

    public abstract class RingSingleton<T> : MonoBehaviour where T : RingSingleton<T>
{
    private static T _instance;

    public enum ChangeDestroy
    {
        DontDestroy,
        Destroy
    }

    public ChangeDestroy _changDestroy = ChangeDestroy.Destroy;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    UnityEngine.Debug.LogError("An instance of " + typeof(T) +
                                               " is needed in the scene, but there is none.");
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = (T)this;
        if (_changDestroy == ChangeDestroy.DontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}


    #endregion Base Method
