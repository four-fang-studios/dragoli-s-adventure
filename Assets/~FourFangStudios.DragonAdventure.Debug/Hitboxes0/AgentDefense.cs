using UnityEngine;
using FourFangStudios.DragonAdventure.Hitboxes;

namespace FourFangStudios.DragonAdventure.Debug.Hitboxes0
{
  /// <summary>
  /// Agent for debugging the HitboxSetController.
  /// </summary>
  public class AgentDefense : MonoBehaviour
  {
    protected void Start()
    {
      // setup defensive hitboxes
      foreach (Hitbox iHitbox in this.hitboxesDefensive.CreateGroup("defense"))
      {
        iHitbox.OnTriggerEntered.AddListener(this.HitboxDefensiveOnTriggerEntered);
      }
    }

    /// <summary>
    /// Raised when hitbox defensive collides with another.
    /// hitbox which entered this one.
    /// </summary>
    protected void HitboxDefensiveOnTriggerEntered(GameObject hitbox, Collider other)
    {
      hitbox.GetComponentInParent<Renderer>().material.color = Color.red;
    }

    [SerializeField] private HitboxGroupController hitboxesDefensive;
  }
}