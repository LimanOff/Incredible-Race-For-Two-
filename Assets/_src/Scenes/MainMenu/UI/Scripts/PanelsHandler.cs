using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PanelsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _panels;

    private void OnEnable()
    {
        ShowPanel("MainPanel");
    }  

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

    public void BackToMainMenu()
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

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
