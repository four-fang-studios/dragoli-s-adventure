using System;
using UnityEngine;
using UnityEngine.Events;

namespace FourFangStudios.DragonAdventure.Runtime
{
  /// <summary>
  /// UnityEngine.UnityEvent for a UnityEngine.Collision.
  /// </summary>
  [Serializable]
  public class UnityEventGameObjectCollision : UnityEvent<GameObject, Collision>
  {

  }
}