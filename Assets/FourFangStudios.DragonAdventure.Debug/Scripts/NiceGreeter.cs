using System;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class NiceGreeter : IGreeter
  {
    private readonly BehaviorSubject<uint> _greets = new BehaviorSubject<uint>(0);

    public IObservable<uint> Greets => this._greets.AsObservable();

    public void Greet(string name)
    {
      this._greets.OnNext(this._greets.Value + 1);
      name = name ?? "world";
      UnityEngine.Debug.Log($"Hello, {name}!");
    }
  }
}
