using System;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public interface IGreeter
  {
    IObservable<int> Greets { get; }
    
    void Greet(string name);
  }
}
