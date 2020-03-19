using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  static public class Utils
  {
    /// <summary>
    /// Instantiate a Hitbox entity from a HitboxAsset.
    /// </summary>
    static public Hitbox Instantiate(this HitboxData thisData, string name)
    {
      // initialize hitbox enitty
      GameObject hitboxEntity = new GameObject($"hitbox-{name}");
      hitboxEntity.layer = thisData.Layer.Index;
      hitboxEntity.transform.parent = thisData.Parent;
      hitboxEntity.transform.localPosition = thisData.LocalPosition;
      hitboxEntity.transform.localScale = Vector3.one;

      Hitbox hitbox = hitboxEntity.AddComponent<Hitbox>(); // hitbox component

      // add collider to hitbox via shape
      Collider collider;
      switch (thisData.Shape)
      {
        case Shape.Sphere:
          SphereCollider sphereCollider = hitboxEntity.AddComponent<SphereCollider>();

          sphereCollider.radius = thisData.Size.x;

          collider = sphereCollider;

          break;
        case Shape.Capsule:

          CapsuleCollider capsuleCollider = hitboxEntity.AddComponent<CapsuleCollider>();

          capsuleCollider.radius = thisData.Size.x;
          capsuleCollider.height = thisData.Size.y;

          capsuleCollider.direction = thisData.Direction;

          collider = capsuleCollider;

          break;
        case Shape.Box:
          BoxCollider boxCollider = hitboxEntity.AddComponent<BoxCollider>();

          boxCollider.size = thisData.Size;

          collider = boxCollider;

          break;
        default: throw new NotSupportedException($"Hitbox shape '{thisData.Shape}' not supported.");
      }
      collider.isTrigger = true;

      // add kinematic rigidbody
      Rigidbody rigidbody = hitboxEntity.AddComponent<Rigidbody>();
      rigidbody.isKinematic = true;
      rigidbody.useGravity = false;
      rigidbody.mass = 1;
      rigidbody.drag = 0;
      rigidbody.angularDrag = 0;

      return hitbox;
    }
  }
}