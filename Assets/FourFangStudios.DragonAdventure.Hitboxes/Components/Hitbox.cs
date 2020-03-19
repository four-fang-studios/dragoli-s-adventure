using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Hitbox or a Hurtbox.
  /// Hitboxes are kinematic rigidbody trigger colliders.
  /// Bubbles up OnTrigger messages via UnityEvents.
  /// </summary>
  public class Hitbox : MonoBehaviour
  {
    // NEGA: we may find it necessary to "filter" collision events on specific hitboxes. eg, by tag

    #region UnityEvents

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventHitboxHitbox OnEntered = new UnityEventHitboxHitbox();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventHitboxHitbox OnExited = new UnityEventHitboxHitbox();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventHitboxHitbox OnStayed = new UnityEventHitboxHitbox();

    #endregion

    #region MonoBehaviour Messages

    private MissingComponentException newException(Collider collider) => new MissingComponentException($"No Hitbox Component on {collider.gameObject.name}. Ensure hitboxes can only collide with other hitboxes in the Physics matrix.");

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnTriggerEnter(Collider collider)
    {
      Hitbox hitbox = collider.gameObject.GetComponent<Hitbox>();

      if (!hitbox) throw newException(collider);

      this.OnEntered.Invoke(this, hitbox);
    }

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnTriggerExit(Collider collider)
    {
      Hitbox hitbox = collider.gameObject.GetComponent<Hitbox>();

      if (!hitbox) throw newException(collider);

      this.OnExited.Invoke(this, hitbox);
    }

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnTriggerStay(Collider collider)
    {
      Hitbox hitbox = collider.gameObject.GetComponent<Hitbox>();

      if (!hitbox) throw newException(collider);

      this.OnStayed.Invoke(this, hitbox);
    }

    #endregion
  }
}