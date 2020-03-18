using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Data about a hitbox.
  /// </summary>
  [CreateAssetMenu(fileName = "HitboxAsset", menuName = "4FS / Hitbox")]
  public class HitboxAsset : ScriptableObject
  {
    /// <summary>
    /// Layer to instantiate the hitbox into.
    /// </summary>
    public Layer Layer;

    /// <summary>
    /// Shape of the hitbox.
    /// Determines collider.
    /// </summary>
    public Shape Shape;

    /// <summary>
    /// Size of the hitbox.
    /// </summary>
    public Vector3 Size;

    /// <summary>
    /// CapsuleCollider.direction.
    /// Capsules only.
    /// </summary>
    public int Direction;

    /// <summary>
    /// Local position of the hitbox.
    /// </summary>
    public Vector3 LocalPosition;
  }
}