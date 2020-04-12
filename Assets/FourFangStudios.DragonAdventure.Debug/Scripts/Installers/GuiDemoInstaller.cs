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
    }
  }
}
