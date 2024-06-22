using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if (activeScene != "MainMenu" && activeScene != "ClassSelection")
        {
            Destroy(this.gameObject);
        }
    }
}
