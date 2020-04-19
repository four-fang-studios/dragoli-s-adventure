using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using UniRx;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public class ElementHudGui : MonoBehaviour
  {
    [Inject] private ICycler<Element> _elementCycler;
    [Inject] private IDictionary<Element, Texture2D> _elementIconMap;
    [SerializeField] private UnityEngine.UI.ScrollRect iconsPanel;
    [SerializeField] public UnityEngine.UI.RawImage[] elementIcons;
    [SerializeField] public float scrollSpeedMultiplier = 400f;

    private Vector2 initialIconsPanelContentPosition;
    private bool scrolling = false;

    private void Start()
    {
      this.initialIconsPanelContentPosition = this.iconsPanel.content.transform.position;
      this.ObserveKeyPressings();
      this._elementCycler.Element.Do(this.OnElementPreCycle).Subscribe();
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
    
    private IObservable<float> OnScrollVelocityXReachesZero() 
    {
      return Observable.EveryFixedUpdate().Select(_ => this.iconsPanel.velocity.x).Where(v => (v == 0f)).Take(1);
    }

    private void ResetIconsScrollView() 
    {
      int arraySize = this.elementIcons.Length;
      int halfArraySize = (int)(Mathf.Floor(arraySize/2));
      this.iconsPanel.content.transform.position = this.initialIconsPanelContentPosition;

      for (int i = 0; i < arraySize; i++) {
        Element e = this._elementCycler.getElementAtCurrentIndexOffset(i-halfArraySize);
        //this.elementIcons[i].texture = this._elementIconMap[e]; // ADD TEXTURES
        this.elementIcons[i].color = new Color(e.Color.r, e.Color.g, e.Color.b, 1);
      }
    }

    public void OnElementPreCycle(Element activeElem) 
    {
      if (!this.scrolling) {
        float scrollSpeed = -(this._elementCycler.CycleDirection * this.scrollSpeedMultiplier);
        this.iconsPanel.velocity = new Vector2(scrollSpeed, 0f);
        this.OnElementCycleStart();
        this.OnScrollVelocityXReachesZero().Do(_ => { 
          this.iconsPanel.velocity = Vector2.zero;
          this.OnElementCycleEnd(); 
        }).Subscribe();
      }
    }

    public void OnElementCycleStart() 
    {
      UnityEngine.Debug.Log("onElementCycleStart");
      this.scrolling = true;
    }

    public void OnElementCycleEnd() 
    {
      UnityEngine.Debug.Log("onElementCycleEnd");
      this.scrolling = false;
      this.ResetIconsScrollView();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      ((IEndDragHandler)iconsPanel).OnEndDrag(eventData);
      UnityEngine.Debug.Log("test");
      
    }
  }
}
