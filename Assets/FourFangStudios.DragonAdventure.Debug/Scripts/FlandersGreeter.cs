using System;
using System.Linq;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class FlandersGreeter : IGreeter
  {
    private readonly BehaviorSubject<uint> _greets = new BehaviorSubject<uint>(0);

    public IObservable<uint> Greets => this._greets.AsObservable();

    public void Greet(string name)
    {
      this._greets.OnNext(this._greets.Value + 1);
      name = name ?? "world";
      if (IsVowel(name.Last()))
        name = name.Substring(0, name.Length - 2);
      name += "ino";
      UnityEngine.Debug.Log($"Howdily doodily {name}!");
    }

    private static bool IsVowel(char c)
    {
      var x = (long)(char.ToUpper(c)) - 64;
      return x * x * x * x * x - 51 * x * x * x * x + 914 * x * x * x - 6894 * x * x + 20205 * x - 14175 == 0;
    }
  }
}
