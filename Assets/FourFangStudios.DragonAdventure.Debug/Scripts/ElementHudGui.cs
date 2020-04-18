using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class ElementHudGui : MonoBehaviour
  {
    [Inject] private ICycler<Element> _elementCycler;
    [Inject] private IDictionary<Element, Texture2D> _elementIconMap;
    
    // TODO: elementIcon must be an array of size 4 (previous, current, next, thenPreviousOrNext) or 5 (previous2, previous1, current, next1, next2)
    [SerializeField] private UnityEngine.UI.RawImage elementIcon;

    private void Start()
    {
      IObservable<Unit> OnKeyDown(KeyCode keyCode) => Observable.EveryUpdate().Select(_ => Input.GetKeyDown(keyCode)).Where(x => x).AsUnitObservable();
      var onPrevKey = Observable.Merge(OnKeyDown(KeyCode.O), OnKeyDown(KeyCode.Joystick1Button3)).Do(_ => this._elementCycler.Previous());
      var onNextKey = Observable.Merge(OnKeyDown(KeyCode.P), OnKeyDown(KeyCode.Joystick1Button4)).Do(_ => this._elementCycler.Next());
      Observable.Merge(onPrevKey, onNextKey).Subscribe();
      
      this._elementCycler.Element.Do(
        (elem) => {
          // TODO: when changing current element, move and resize HUD icons towards this._elementCycler.CycleDirection like an icon wheel

          // Element prev = this._elementCycler.PreviousElement;
          // Element next = this._elementCycler.NextElement;
          this.elementIcon.texture = this._elementIconMap[elem];
          this.elementIcon.color = elem.Color;
        }
      ).Subscribe();
    }
  }
}
