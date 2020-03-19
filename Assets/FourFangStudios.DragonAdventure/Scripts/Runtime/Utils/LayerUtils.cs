using UnityEngine;

namespace FourFangStudios.DragonAdventure
{
  static public class LayerUtils
  {
    /// <summary>
    /// Returns a value between [0;31].
    /// Important: This will only work properly if the LayerMask is one created in the inspector and not a LayerMask
    /// with multiple values.
    /// </summary>
    public static int GetLayerNumber(this LayerMask thisLayerMask)
    {
      var bitmask = thisLayerMask.value;
      int result = bitmask > 0 ? 0 : 31;
      while (bitmask > 1)
      {
        bitmask = bitmask >> 1;
        result++;
      }
      return result;
    }
  }
}