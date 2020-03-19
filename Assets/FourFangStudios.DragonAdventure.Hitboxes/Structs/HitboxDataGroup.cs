using System;
using Malee;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Group of HitboxData.
  /// </summary>
  [Serializable]
  public struct HitboxDataGroup
  {
    /// <summary>
    /// Id of the HitboxCollection.
    /// </summary>
    public string Id;

    /// <summary>
    /// Hitbox Data within this set.
    /// </summary>
    [Reorderable(singleLine = true)]
    public HitboxDataList HitboxDatas;
  }
}