using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Runtime.Hitboxes
{
  /// <summary>
  /// Runtime hitbox data.
  /// Bound to a specific transform.
  /// </summary>
  [Serializable]
  public struct HitboxData
  {
    /// <summary>
    /// GroupId of the Hitbox to create.
    /// </summary>
    public string GroupId;

    /// <summary>
    /// Layer to instantiate the hitbox into.
    /// </summary>
    public Layer Layer;

    /// <summary>
    /// Bone to be instantiated upon.
    /// </summary>
    public Transform Parent;

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