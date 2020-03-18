using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Runtime hitbox data.
  /// Bound to a specific transform.
  /// </summary>
  [Serializable]
  public struct HitboxData
  {
    /// <summary>
    /// Bone to be instantiated upon.
    /// </summary>
    public Transform Parent;

    /// <summary>
    /// Asset to isntantiate from.
    /// </summary>
    public HitboxAsset Asset;
  }
}