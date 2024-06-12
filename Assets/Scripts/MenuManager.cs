using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject gameModeMenu;
    public bool isInGame;
    public bool isOpen;

    public AudioSource clickAudioSource;
    public AudioSource hoverAudioSource;

    
    public void OnMenuOpen(Component sender, object data)
    {
        closeAll();
        if (isOpen)
        {
            isOpen = false;
            return;
        }
        isOpen = true;
        mainMenu.SetActive(true);
    }

    private void closeAll()
    {
        foreach (var menu in new List<GameObject>{mainMenu, settingsMenu})
        {
            menu.SetActive(false);
        }
    }
    
    #region MainMenu

    public void OnMainMenuPlayClicked()
    {
        if (isInGame)
        {
            closeAll();
            isOpen = false;
            return;
        }
        mainMenu.SetActive(false);
        gameModeMenu.SetActive(true);
    }
    
    public void OnMainMenuSettingsClicked()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnMainMenuQuitClicked()
    {
        if (!isInGame)
        {
            Application.Quit();
            return;
        }

        SceneManager.LoadScene("MainMenu");
    }
    
    #endregion

    #region SettingsMenu
    
    public void OnSettingsMenuBackClicked()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    #endregion

    #region GameModeSelection

    public void OnGameModeOneClicked()
    {
        SceneManager.LoadScene("mission_low_flight");
    }

    public void OnGameModeTwoCLicked()
    {
        SceneManager.LoadScene("scene_bastien");
    }

    public void OnGameModeBackClicked()
    {
        gameModeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    #endregion

    #region Sound
    
    public void PlayClickSound()
    {
        clickAudioSource.Play();
    }
    
    public void PlayHoverSound()
    {
        hoverAudioSource.Play();
    }

    #endregion
}
