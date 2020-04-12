using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGui : MonoBehaviour
{

  public static bool IsGamePaused = false;
  public GameObject pausePanel;
  public GameObject settingsPanel;

  protected void Update()
  {
      if (Input.GetButtonDown("Toggle Pause")) {
        if (!IsGamePaused) {
          Pause();
        } else {
          Resume();
        }
      }
  }

  public void Pause() {
    pausePanel.SetActive(true);
    Time.timeScale = 0f;
    IsGamePaused = true;
  }

  public void Resume() {
    if (settingsPanel.activeInHierarchy) {
      settingsPanel.SetActive(false);
    }
    pausePanel.SetActive(false);
    Time.timeScale = 1f;
    IsGamePaused = false;
  }

  public void ViewSettings() {
    settingsPanel.SetActive(true);
    pausePanel.SetActive(false);
  }

  public void CloseSettings() {
    pausePanel.SetActive(true);
    settingsPanel.SetActive(false);
  }

  public void Quit() {
    Application.Quit();
  }
}
