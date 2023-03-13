using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _panels;
    private void ShowPanel(string NameOfPanelThatShouldBeShown)
    {
        for(int index = 0; index < _panels.Length; index++)
        {
            if(_panels[index].gameObject.name == NameOfPanelThatShouldBeShown)
            {
                _panels[index].Activate();
            }
            else
            {
                HidePanel(_panels[index]);
            }
        }
    }

    private void HidePanel(GameObject panel)
    {
        panel.Deactivate();
    }

    public void BackToMainMenuPanel()
    {
        ShowPanel("MainPanel");
    }

    public void OpenSettingsPanel()
    {
        ShowPanel("SettingsPanel");
    }

    public void OpenLevelsPanel()
    {
        ShowPanel("LevelsPanel");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel()
    {
        int levelNumber = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);

        SceneManager.LoadScene($"{levelNumber}_Level");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene($"MainMenu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
