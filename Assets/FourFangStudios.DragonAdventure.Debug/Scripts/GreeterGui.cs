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

     void Start()
    {
      this._greeter.Greets.Select(x => $"Greet count: {x.ToString()}").Subscribe(
        (string msg) => {
          UnityEngine.Debug.Log(msg);
          this.greetingsCountLabel.text = msg;
        }
      );
      this.greetingButton.onClick.AddListener(
        () => { 
          this._greeter.Greet("Homer");
        }
      );
    }
  }
}
