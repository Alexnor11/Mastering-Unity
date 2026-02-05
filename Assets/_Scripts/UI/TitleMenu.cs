using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    /// <summary>
    /// Когда пользователь нажимает кнопку "Start Game",
    /// необходимо загрузить сцену MainGame.
    /// </summary>
    public void onPressStartGameBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
