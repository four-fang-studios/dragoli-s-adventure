using System.Collections.Generic;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Has groups of hitboxes, via their Hitbox.GroupId.
  /// </summary>
  public class HitboxController : MonoBehaviour
  {
    #region Methods / Public

    /// <summary>
    /// Set Collider.enabled of all Hitbox with GroupId.
    /// </summary>
    public void SetGroupActive(string groupId, bool value)
    {
      IEnumerable<Hitbox> hitboxGroup = this._hitboxes[groupId];
      foreach (Hitbox iHitbox in hitboxGroup)
      {
        iHitbox.gameObject.SetActive(value);
      }
    }

    /// <summary>
    /// Get a group of hitboxes.
    /// </summary>
    public IEnumerable<Hitbox> GetGroup(string groupId) => this._hitboxes[groupId];

    #endregion

    #region MonoBehaviour Messages

    protected void Awake()
    {
      // convert hitboxes into a dictionary

      Hitbox[] hitboxComponents = this.GetComponentsInChildren<Hitbox>();
      foreach (Hitbox iHitbox in hitboxComponents)
      {
        // get hitbox group, creating new if needed
        if (!this._hitboxes.TryGetValue(iHitbox.GroupId, out List<Hitbox> hitboxGroup))
        {
          hitboxGroup = new List<Hitbox>();
          _hitboxes.Add(iHitbox.GroupId, hitboxGroup);
        }

        hitboxGroup.Add(iHitbox); // add hitbox to the group
      }
    }

    #endregion

    #region Fields

    /// <summary>
    /// Hitbox Component, cached into a dictionary.
    /// key: HitboxDataCollection.Id.
    /// value: Hitbox entities.
    /// </summary>
    private IDictionary<string, List<Hitbox>> _hitboxes = new Dictionary<string, List<Hitbox>>();

    #endregion
  }
}