using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Has groups of hitboxes which can be created/ destroyed with an id.
  /// Only one collection of hitboxes can be "active" (created) at a time.
  /// </summary>
  public class HitboxGroupController : MonoBehaviour
  {
    #region Methods / Public

    /// <summary>
    /// Create Hitbox entities for each HitboxData in the HitboxDataGroup.
    /// </summary>
    public void CreateHitboxGroup(string groupId)
    {
      // check there are no active hitboxes first
      if (this.IsHitboxesActive)
      {
        throw new InvalidOperationException("There are already active hitboxes! Clear them before creating new hitboxes.");
      }

      // get hitbox collection. throws an exception if there is no hitbox set with that id
      HitboxDataGroup hitboxDataGroup = this._hitboxGroups[groupId];

      // allocate new active hitboxes
      this._hitboxesActive = new Hitbox[hitboxDataGroup.HitboxDatas.Length];

      // create each hitbox
      for (int i = 0; i < hitboxDataGroup.HitboxDatas.Length; i++)
      {
        // create hitbox
        this._hitboxesActive[i] = hitboxDataGroup.HitboxDatas[i].Instantiate($"{groupId}-{i}");
      }
    }

    /// <summary>
    /// Clear active hitboxes.
    /// </summary>
    public bool ClearActiveGroup()
    {
      if (this.IsHitboxesActive)
      {
        // there are active hitboxes

        // destroy active hitboxes
        // NEGA: this may become a performance bottleneck, depending on the amount of hitboxes created and destroyed
        for (int i = 0; i < this._hitboxesActive.Length; i++)
        {
          UnityEngine.Object.Destroy(this._hitboxesActive[i]);
        }

        this._hitboxesActive = null;

        return true;
      }
      else
      {
        // there are no active hitboxes

        return false;
      }
    }

    /// <summary>
    /// Convenience method to quickly set Collider.enabled on active hitboxes.
    /// (eg, on taking damage)
    /// </summary>
    public void SetActiveHitboxCollidersEnabled(bool value)
    {
      if (this._hitboxesActive == null) return;

      for (int i = 0; i < this._hitboxesActive.Length; i++)
      {
        this._hitboxesActive[i].GetComponent<Collider>().enabled = value;
      }
    }

    /// <summary>
    /// Are there any active hitboxes?
    /// </summary>
    public bool IsHitboxesActive => this._hitboxesActive != null && this._hitboxesActive.Any();

    /// <summary>
    /// The active Hitbox Components.
    /// Returned value may be null.
    /// </summary>
    public Hitbox[] HitboxesActive => this._hitboxesActive;

    #endregion

    #region MonoBehaviour Messages

    public void Awake()
    {
      // convert hitboxes into a dictioanry
      this._hitboxGroups = this.hitboxGroups.ToDictionary((i) => i.Id, (i) => i);
    }

    #endregion

    #region Fields

    /// <summary>
    /// Active hitboxes.
    /// </summary>
    private Hitbox[] _hitboxesActive = null;

    /// <summary>
    /// HitboxData, stored into a dictionary.
    /// key: HitboxDataCollection.Id.
    /// value: HitboxDataCollection.Hitboxes.
    /// </summary>
    private IDictionary<string, HitboxDataGroup> _hitboxGroups;

    #endregion

    #region Inspector / Prefabs

    /// <summary>
    /// HitboxDataGroups, which will be cached to a dictionary.
    /// </summary>
    [SerializeField] private HitboxDataGroup[] hitboxGroups;

    #endregion
  }
}