using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FourFangStudios.DragonAdventure.Debug.Scripts.Installers
{
  public class GuiDemoInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      this.Container
        .Bind<IGreeter>()
        // Just pick one.
        .To<NiceGreeter>()
        // .To<MeanGreeter>()
        // .To<FlandersGreeter>()
        .AsSingle();

      this.Container
        .Bind<IEnumerable<Element>>()
        .FromMethod(c => new[] {Element.Neutral, Element.Fire, Element.Water, Element.Wind})
        .AsSingle();
      
      this.Container
        .Bind<IDictionary<Element, Texture2D>>()
        .FromMethod(c => new Dictionary<Element, Texture2D>
        {
          {Element.Neutral, Resources.Load<Texture2D>("NeutralMask")},
          {Element.Fire, Resources.Load<Texture2D>("FireMask")},
          {Element.Water, Resources.Load<Texture2D>("WaterMask")},
          {Element.Wind, Resources.Load<Texture2D>("WindMask")}
        })
        .AsSingle();

      this.Container
        .Bind<ICycler<Element>>()
        .To<ElementCycler>()
        .AsSingle();
    }
  }
}
