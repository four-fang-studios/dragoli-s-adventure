using System;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public interface IGreeter
  {
    IObservable<uint> Greets { get; }
    
    void Greet(string name);
  }
}
