using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class GreeterGui : MonoBehaviour
  {
    [Inject] private IGreeter _greeter;
    public UnityEngine.UI.Button greetingButton;
    public UnityEngine.UI.Text greetingsCountLabel;

    private void Start()
    {
      this._greeter.Greets
        .Select(x => x == 0
          ? "You haven't greeted me yet"
          : $"Greet count: {x}")
        .Subscribe(
          msg =>
          {
            UnityEngine.Debug.Log(msg);
            this.greetingsCountLabel.text = msg;
          }
        );
      
      this.greetingButton.onClick.AddListener(
        () =>
        {
          this._greeter.Greet("Homer");
        }
      );
    }
  }
}
