using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  static public class Utils
  {
    /// <summary>
    /// Instantiate a Hitbox entity from a HitboxAsset.
    /// </summary>
    static public Hitbox Instantiate(this HitboxAsset thisAsset, Transform parent, string name)
    {
      // initialize hitbox enitty
      GameObject hitboxEntity = new GameObject($"hitbox-{name}");
      hitboxEntity.layer = thisAsset.Layer.Index;
      hitboxEntity.transform.parent = parent;
      hitboxEntity.transform.localPosition = thisAsset.LocalPosition;
      hitboxEntity.transform.localScale = Vector3.one;

      Hitbox hitbox = hitboxEntity.AddComponent<Hitbox>(); // hitbox component

      // add collider to hitbox via shape
      Collider collider;
      switch (thisAsset.Shape)
      {
        case Shape.Sphere:
          SphereCollider sphereCollider = hitboxEntity.AddComponent<SphereCollider>();

          sphereCollider.radius = thisAsset.Size.x;

          collider = sphereCollider;

          break;
        case Shape.Capsule:

          CapsuleCollider capsuleCollider = hitboxEntity.AddComponent<CapsuleCollider>();

          capsuleCollider.radius = thisAsset.Size.x;
          capsuleCollider.height = thisAsset.Size.y;

          capsuleCollider.direction = thisAsset.Direction;

          collider = capsuleCollider;

          break;
        case Shape.Box:
          BoxCollider boxCollider = hitboxEntity.AddComponent<BoxCollider>();

          boxCollider.size = thisAsset.Size;

          collider = boxCollider;

          break;
        default: throw new NotSupportedException($"Hitbox shape '{thisAsset.Shape}' not supported.");
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

    /// <summary>
    /// Instantiate a Hitbox entity from a HitboxData.
    /// </summary>
    static public Hitbox Instantiate(this HitboxData thisData, string name) =>
      thisData.Asset.Instantiate(thisData.Parent, name);
  }
}