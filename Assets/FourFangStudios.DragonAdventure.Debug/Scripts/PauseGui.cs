using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class PauseGui : MonoBehaviour
  {
    [Inject] private IGreeter _greeter;
    
    private bool _isGamePaused = false;
    public GameObject pausePanel;
    public GameObject settingsPanel;

    private void Start()
    {
      this._greeter.Greets.Select(x => $"Greet count: {x.ToString()}").Subscribe(UnityEngine.Debug.Log);
    }

    protected void Update()
    {
      if (Input.GetButtonDown("Toggle Pause")) {
        if (!this._isGamePaused) {
          this.Pause();
        } else {
          this.Resume();
        }
      }
    }

    private void Pause() {
      this._greeter.Greet("Homer");
      this.pausePanel.SetActive(true);
      Time.timeScale = 0f;
      this._isGamePaused = true;
    }

    private void Resume() {
      if (this.settingsPanel.activeInHierarchy) {
        this.settingsPanel.SetActive(false);
      }
      this.pausePanel.SetActive(false);
      Time.timeScale = 1f;
      this._isGamePaused = false;
    }

    public void ViewSettings() {
      this.settingsPanel.SetActive(true);
      this.pausePanel.SetActive(false);
    }

    public void CloseSettings() {
      this.pausePanel.SetActive(true);
      this.settingsPanel.SetActive(false);
    }

    public void Quit() {
      Application.Quit();
    }
  }
}
