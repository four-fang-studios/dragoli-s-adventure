using System;
using System.Collections.Generic;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public interface ICycler<T> : IReadOnlyList<T>
  {
    int CycleDirection { get; }
    T PreviousElement { get; }
    T NextElement { get; }
    IObservable<T> Element { get; }
    void Previous();
    void Next();
  }
}
