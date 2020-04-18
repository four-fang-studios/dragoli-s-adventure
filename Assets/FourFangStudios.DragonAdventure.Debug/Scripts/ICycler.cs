using System;
using System.Collections.Generic;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public interface ICycler<T> : IReadOnlyList<T>
  {
    int CycleDirection { get; }
    IObservable<T> Element { get; }
    T getElementAtCurrentIndexOffset(int offset);
    void Previous();
    void Next();
  }
}
