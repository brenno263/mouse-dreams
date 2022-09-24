using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseButton : MonoBehaviour

{

    public int n;

    public void OnButtonClick()

    {

        SceneManager.LoadScene(0);

    }

}