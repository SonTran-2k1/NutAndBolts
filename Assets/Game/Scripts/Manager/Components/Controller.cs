using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Ring;
using UnityEngine.Serialization;

namespace Controller
{
    #region Component

    #region Main Game

    public enum StateGame
    {
        Empty,
        Move,
        Win,
        Lose
    }

    public enum StateNail
    {
        Down,
        Up
    }

    public enum StateDot
    {
        HaveNot,
        Have
    }

    public enum StateNumberNails
    {
        Nail_1 = 0,
        Nail_2 = 1,
        Nail_3 = 2,
        Nail_4 = 3,
        Nail_5 = 4,
        Nail_6 = 5,
        Nail_7 = 6
    }

    [Serializable]
    public class GameController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Move for Nail Controller")] [ChangeColorLabel(0.2f, 1, 1)]
        public List<DotManager> listNail;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public NailManager nailCurrent;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public StateGame stateGamePlay;

        [ChangeColorLabel(0.2f, 1, 1)] public Tween tweenMoveNail;
    }

    [Serializable]
    public class DotController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Dot Controller")] [ChangeColorLabel(0.2f, 1, 1)]
        public Collider2D myDotCollider;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public Collider2D DotCollider;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public StateDot stateDot;
    }

    [Serializable]
    public class NailController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Sprites Nail")] [ChangeColorLabel(0.2f, 1, 1)]
        public Transform headNail;

        [ChangeColorLabel(0.2f, 1, 1)] public Transform parentNail;
        //[ChangeColorLabel(0.2f, 1, 1)] public Transform bottomNail;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public float upPosition;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public float downPosition;

        [ReadOnly] [ChangeColorLabel(0.2f, 1, 1)]
        public StateNail stateNail;

        [ChangeColorLabel(0.2f, 1, 1)] [SearchableEnum]
        public StateNumberNails stateNumberNail;

        [Help("chỉ được kéo ref vào ngay ban đầu , in game sẽ tự động add vào dot")] [ChangeColorLabel(0.2f, 1, 1)]
        public DotManager currentDot;
    }

    [Serializable]
    public class WoodController
    {
        [HeaderTextColor(0.9f, .1f, .1f, headerText = "Sprites Nail")] [ChangeColorLabel(0.2f, 1, 1)]
        public List<HingeJoint2D> listJoint;
    }

    #endregion

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
        public GameObject winPopup;

        [ChangeColorLabel(0.2f, 1, 1)] public GameObject losePopup;
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
