using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseButton : MonoBehaviour

{

    public int n;

    public void ToExplanation()

    {

        SceneManager.LoadScene(2);

    }

    public void ToGame()

    {

        SceneManager.LoadScene(4);

    }

    public void ToMainMenu()

    {

        SceneManager.LoadScene(1);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}