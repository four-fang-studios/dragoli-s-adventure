using System;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class MeanGreeter : IGreeter
  {
    private readonly BehaviorSubject<int> _greets = new BehaviorSubject<int>(0);

    public IObservable<int> Greets => this._greets.AsObservable();

    public void Greet(string name)
    {
      this._greets.OnNext(this._greets.Value + 1);
      name = name ?? "world";
      UnityEngine.Debug.Log($"Fuck you {name}");
    }
  }
}
