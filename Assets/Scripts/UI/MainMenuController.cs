using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using Button = UnityEngine.UIElements.Button;

public class MainMenuController : MonoBehaviour
{
    public UIDocument m_Doc;
    public VisualElement m_Root;
    public VisualElement m_MenuBackground;
    public Button m_StartButton;
    public Button m_CreditsButton;
    public Button m_CloseButton;
    

    // Start is called before the first frame update
    void Start()
    {
        BuildUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildUI()
    {
        Debug.Log("Before m_Root ");
        m_Root = m_Doc.rootVisualElement;
        
        //  int x = m_Root.childCount;
        //Debug.Log(x);
        Debug.Log(m_Root.Children());
        m_MenuBackground = m_Root.Q<VisualElement>("MainMenuBackground");
        m_StartButton = m_MenuBackground.Q<Button>("StartButton");
       // m_CreditsButton = m_Root.Q<Button>("CreditsButton");
        //m_CloseButton = m_Root.Q<Button>("CloseButton");
        m_StartButton.text = "kkkkkkkkkkk";
        //Debug.Log(m_StartButton.text = "a");
      //  m_StartButton.clickable.clicked += StartGame;
       // Debug.Log("After Clickable");
        //m_CreditsButton.clickable.clicked += LoadCredits;
        //m_CloseButton.clickable.clicked += CloseGame;
    }

    void StartGame()
    {
        // SceneManager.LoadScene(0);
        Debug.Log("PlayPressed!");
    }
    void LoadCredits()
    {

    }
    void CloseGame()
    {

    }

}
