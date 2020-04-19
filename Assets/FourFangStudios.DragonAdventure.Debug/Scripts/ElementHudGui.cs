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
    [SerializeField] private RectTransform iconsPanel;
    [SerializeField] public UnityEngine.UI.RawImage[] elementIcons;

    private int xPixelsLeft = 0;

    private void Start()
    {
      this.ObserveKeyPressings();
      this._elementCycler.Element.Do(this.onElementCycleStart).Subscribe();
    }

    private void Update() {
      if (this.xPixelsLeft != 0) {
        Vector3 iconsPosVector = this.iconsPanel.position;
        Vector3 newIconsPosVector;
        if (this.xPixelsLeft > 0) {
          newIconsPosVector = new Vector3(iconsPosVector.x - 1f, iconsPosVector.y, iconsPosVector.z);
        } else {
          newIconsPosVector = new Vector3(iconsPosVector.x + 1f, iconsPosVector.y, iconsPosVector.z);
        }
          Vector3.MoveTowards(this.iconsPanel.position, newIconsPosVector, 1f);
      }
    }

    private void ObserveKeyPressings()
    {
      IObservable<Unit> OnKeyDown(KeyCode keyCode) => Observable.EveryUpdate().Select(_ => Input.GetKeyDown(keyCode)).Where(x => x).AsUnitObservable();

      var onPrevKey = Observable.Merge(
        OnKeyDown(KeyCode.O), 
        OnKeyDown(KeyCode.Joystick1Button3)
      ).Do(_ => this._elementCycler.Previous());
      var onNextKey = Observable.Merge(
        OnKeyDown(KeyCode.P), 
        OnKeyDown(KeyCode.Joystick1Button4)
      ).Do(_ => this._elementCycler.Next());
      
      Observable.Merge(onPrevKey, onNextKey).Subscribe();
    }

    private void onElementCycleStart(Element activeElem) 
    {
      int arraySize = this.elementIcons.Length;
      int halfArraySize = (int)(Mathf.Floor(arraySize/2));

      for (int i = 0; i < arraySize; i++) {
        
        
        //TODO: Make an equation to make 'alpha' values from 'i as follows
        // [25, 50, 100, 50, 25] when array (values of 'i') is [0, 1, 2, 3, 4]

        int alpha = 100;
        //UnityEngine.Debug.Log(alpha);
        Element e = this._elementCycler.getElementAtCurrentIndexOffset(i-halfArraySize);
        
        // this.elementIcons[2].texture = this._elementIconMap[e];
        this.elementIcons[i].color = new Color(e.Color.r, e.Color.g, e.Color.b, alpha/100);
      }
    }
  }
}
