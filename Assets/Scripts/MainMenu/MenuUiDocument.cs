using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUiDocument : MonoBehaviour
{
    private VisualElement root;
    private Button StartButton;
    private Button DeveloperButton;
    private Button QuitButton;


    // Start is called before the first frame update
    void Start()
    {
        this.root = GetComponent<UIDocument>().rootVisualElement;
        this.StartButton = this.root.Q<Button>("StartButton");
        this.DeveloperButton = this.root.Q<Button>("DeveloperButton");
        this.QuitButton = this.root.Q<Button>("QuitButton");

        this.StartButton.clicked += this.OnStartButtonClicked;
        this.DeveloperButton.clicked += this.OnDeveloperButtonClicked;
        this.QuitButton.clicked += this.OnQuitButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        Debug.Log("Change Scene called");
        SceneManager.LoadScene("MarketScene");
    }

    private void OnDeveloperButtonClicked()
    {
        
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
