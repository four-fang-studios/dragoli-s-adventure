using System;
using System.Collections.Generic;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public interface ICycler<T> : IReadOnlyList<T>
  {
    IObservable<T> Element { get; }
    void Previous();
    void Next();
  }
}
