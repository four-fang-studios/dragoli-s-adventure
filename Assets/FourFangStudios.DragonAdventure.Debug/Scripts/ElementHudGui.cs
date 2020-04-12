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
    [Inject] private IDictionary<Element, Texture2D> _map;
    [SerializeField] private UnityEngine.UI.RawImage elementRawImage;

    private void Start()
    {
      IObservable<Unit> OnKeyDown(KeyCode keyCode) => Observable.EveryUpdate().Select(_ => Input.GetKeyDown(keyCode)).Where(x => x).AsUnitObservable();
      var onPrevKey = Observable.Merge(OnKeyDown(KeyCode.O), OnKeyDown(KeyCode.Joystick1Button3)).Do(_ => this._elementCycler.Previous());
      var onNextKey = Observable.Merge(OnKeyDown(KeyCode.P), OnKeyDown(KeyCode.Joystick1Button4)).Do(_ => this._elementCycler.Next());
      Observable.Merge(onPrevKey, onNextKey).Subscribe();
      
      this._elementCycler.Element.Do(x =>
      {
        this.elementRawImage.texture = this._map[x];
        this.elementRawImage.color = x.Color;
      }).Subscribe();
    }
  }
}
