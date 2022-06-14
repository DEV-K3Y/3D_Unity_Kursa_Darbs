using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate = 60;
    [SerializeField] private bool _runInBackground = true;
    [SerializeField] private FadeScreen _fadeScreen;

    public static App Instance;

    public FadeScreen GetFadeScreen() => _fadeScreen;

    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = _targetFrameRate;
        Application.runInBackground = _runInBackground;
    }

    public void Restart(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Finish(){
        _fadeScreen.Show(5f, OnSuccess);

        void OnSuccess(){
            Restart();
        }
    }

    public void Quit(){
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
