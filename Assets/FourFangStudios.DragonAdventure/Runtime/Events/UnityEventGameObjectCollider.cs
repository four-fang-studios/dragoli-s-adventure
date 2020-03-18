using System;
using UnityEngine;
using UnityEngine.Events;

namespace FourFangStudios.DragonAdventure
{
  /// <summary>
  /// UnityEngine.UnityEvent for a UnityEngine.Collider.
  /// </summary>
  [Serializable]
  public class UnityEventGameObjectCollider : UnityEvent<GameObject, Collider>
  {

  }
}