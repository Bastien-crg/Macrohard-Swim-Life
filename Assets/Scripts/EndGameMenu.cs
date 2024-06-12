using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public TextMeshProUGUI endGameText;
    public GameObject endGameCanvas;
    
    public void ShowEndMenu(Component sender, object data)
    {
        if (data is string str)
        {
            endGameText.text = str;
        }

        endGameCanvas.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        endGameCanvas.SetActive(false);
    }

    public void OnQuitClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
