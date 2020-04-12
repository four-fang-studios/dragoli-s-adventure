using UnityEngine;

namespace FourFangStudios.DragonAdventure.Debug.Scripts
{
  public struct Element
  {
    public static Element Neutral = new Element(ElementKind.Neutral, "Neutral", 1f, 1f, 1f, Color.white);
    public static Element Fire = new Element(ElementKind.Fire, "Fire", 1.2f, .9f, .9f, Color.red);
    public static Element Water = new Element(ElementKind.Wind, "Water", .9f, 1.0f, 1.1f, Color.blue);
    public static Element Wind = new Element(ElementKind.Water, "Wind", 1f, 1.2f, .8f, Color.green);

    public ElementKind ElementKind { get; }
    public string Name { get; }
    public float DamageMultiplier { get; }
    public float SpeedMultiplier { get; }
    public float AccuracyMultiplier { get; }
    public Color Color { get; }

    public Element(
      ElementKind elementKind,
      string name,
      float damageMultiplier,
      float speedMultiplier,
      float accuracyMultiplier,
      Color color)
    {
      this.ElementKind = elementKind;
      this.Name = name;
      this.DamageMultiplier = damageMultiplier;
      this.SpeedMultiplier = speedMultiplier;
      this.AccuracyMultiplier = accuracyMultiplier;
      this.Color = color;
    }
  }
}
