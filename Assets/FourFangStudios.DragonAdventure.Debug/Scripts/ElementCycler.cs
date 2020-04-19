using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class ElementCycler : ICycler<Element>
  {
    private readonly Element[] _elements;
    private readonly BehaviorSubject<Element> _element;
    private int _currentIndex;
    private int _cyclingDirection;

    private int Index { 
      get { return this._currentIndex; } 
      set { 
        this._currentIndex = value; 
        var e = this._elements[this._currentIndex];
        this._element.OnNext(e);
      }
    }

    public int CycleDirection => this._cyclingDirection;
    public IObservable<Element> Element => this._element;

    public ElementCycler(IEnumerable<Element> elements)
    {
      var list = elements.ToArray();
      this._elements = list.Length > 0 ? list : throw new ArgumentException("The element cannot be empty.", nameof(elements));
      this._currentIndex = 0;
      this._element = new BehaviorSubject<Element>(Scripts.Element.Neutral);
      this._cyclingDirection = 0;
    }

    public void Next()
    {
      this._cyclingDirection = 1;
      this.Index = (this._currentIndex + 1 > this._elements.Length - 1) ? 
        0 : 
        this._currentIndex + 1;
    }

    public void Previous()
    {
      this._cyclingDirection = -1;
      this.Index = (this._currentIndex - 1 < 0) ? 
        this._elements.Length - 1 : 
        this._currentIndex - 1;
    }
    public Element getElementAtCurrentIndexOffset(int offset) 
    { 
      int elementCount = this._elements.Length;
      int desiredIndex = (this._currentIndex + offset);
      
      while (desiredIndex < 0) {
        desiredIndex += elementCount;
      }
      int maxIndex = (elementCount-1);
      while (desiredIndex > maxIndex) {
        desiredIndex -= elementCount;
      }

      return this._elements[desiredIndex];
    }

    #region IReadonlyList<Element>

    public IEnumerator<Element> GetEnumerator() => ((IEnumerable<Element>)this._elements).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public int Count => this._elements.Length;

    public Element this[int index] => this._elements[index];

    #endregion
  }
}
