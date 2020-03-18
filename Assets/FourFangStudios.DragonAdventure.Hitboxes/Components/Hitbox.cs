using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Hitbox or a Hurtbox.
  /// Hitboxes are kinematic rigidbody trigger colliders.
  /// Bubbles up collision/ trigger messages via UnityEvents.
  /// </summary>
  public class Hitbox : MonoBehaviour
  {
    // NEGA: we may find it necessary to "filter" collision events on specific hitboxes. eg, by tag

    #region UnityEvents

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventGameObjectCollision OnCollisionEntered = new UnityEventGameObjectCollision();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventGameObjectCollision OnCollisionExited = new UnityEventGameObjectCollision();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventGameObjectCollision OnCollisionStayed = new UnityEventGameObjectCollision();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventGameObjectCollider OnTriggerEntered = new UnityEventGameObjectCollider();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventGameObjectCollider OnTriggerExited = new UnityEventGameObjectCollider();

    /// <summary>
    /// Raised by MonoBehaviour message.
    /// </summary>
    public UnityEventGameObjectCollider OnTriggerStayed = new UnityEventGameObjectCollider();

    #endregion

    #region MonoBehaviour Messages

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnTriggerEnter(Collider collider) => this.OnTriggerEntered.Invoke(this.gameObject, collider);

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnTriggerExit(Collider collider) => this.OnTriggerExited.Invoke(this.gameObject, collider);

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnTriggerStay(Collider collider) => this.OnTriggerStayed.Invoke(this.gameObject, collider);

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnCollisionEnter(Collision collision) => this.OnCollisionEntered.Invoke(this.gameObject, collision);

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnCollisionExit(Collision collision) => this.OnCollisionExited.Invoke(this.gameObject, collision);

    /// <summary>
    /// MonoBehaviour message.
    /// </summary>
    protected void OnCollisionStay(Collision collision) => this.OnCollisionStayed.Invoke(this.gameObject, collision);

    #endregion
  }
}