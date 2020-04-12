using UnityEngine;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class PauseRxGui : MonoBehaviour
  {
    private bool _isGamePaused;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private UnityEngine.UI.Button resumeButton;
    [SerializeField] private UnityEngine.UI.Button quitButton;

    private void Start()
    {
      // this.quitButton.onClick.AddListener(this.Quit);
      
      Observable
        .EveryUpdate()
        .Select(_ => Input.GetButtonDown("Toggle Pause"))
        .Where(x => x)
        .Subscribe(_ =>
        {
          if (this._isGamePaused)
            this.ResumeGame();
          else
            this.PauseGame();
        });

      this.resumeButton.OnClickAsObservable().Subscribe(_ => this.ResumeGame());
      this.quitButton.OnClickAsObservable().Subscribe(_ => this.Quit());
    }

    private void PauseGame()
    {
      this.pausePanel.SetActive(true);
      Time.timeScale = 0f;
      this._isGamePaused = true;
    }

    private void ResumeGame()
    {
      if (this.settingsPanel.activeInHierarchy)
        this.settingsPanel.SetActive(false);

      this.pausePanel.SetActive(false);
      Time.timeScale = 1f;
      this._isGamePaused = false;
    }

    private void ViewSettings()
    {
      this.settingsPanel.SetActive(true);
      this.pausePanel.SetActive(false);
    }

    private void CloseSettings()
    {
      this.pausePanel.SetActive(true);
      this.settingsPanel.SetActive(false);
    }

    private void Quit()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
  }
}
