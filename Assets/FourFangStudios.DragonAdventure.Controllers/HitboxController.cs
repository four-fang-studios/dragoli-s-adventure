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
  public class HitboxController : MonoBehaviour
  {
    #region Methods / Public

    /// <summary>
    /// Create Hitbox entities for each HitboxData in the HitboxDataGroup.
    /// </summary>
    public Hitbox[] CreateGroup(string groupId)
    {
      if (this._hitboxesActive.ContainsKey(groupId)) throw new InvalidOperationException($"HitboxGroup with groupId '{groupId}' already created.");

      // get hitbox group data.
      HitboxDataGroup hitboxDataGroup = this._hitboxGroupsData[groupId];

      // allocate new active hitboxes
      Hitbox[] hitboxes = new Hitbox[hitboxDataGroup.HitboxDatas.Length];

      // create each hitbox
      for (int i = 0; i < hitboxDataGroup.HitboxDatas.Length; i++)
      {
        // create hitbox
        hitboxes[i] = hitboxDataGroup.HitboxDatas[i].Instantiate($"{groupId}-{i}");
      }

      // add hitbox groups
      this._hitboxesActive.Add(groupId, hitboxes);

      return hitboxes;
    }

    /// <summary>
    /// Clear active hitboxes.
    /// </summary>
    public void DestroyGroup(string groupId)
    {
      Hitbox[] hitboxes = this._hitboxesActive[groupId];

      // destroy active hitboxes
      // NEGA: this may become a performance bottleneck, depending on the amount of hitboxes created and destroyed
      for (int i = 0; i < hitboxes.Length; i++)
      {
        UnityEngine.Object.Destroy(hitboxes[i]);
      }

      this._hitboxesActive.Remove(groupId);
    }

    public void SetGroupCollidersEnabled(string groupId, bool value)
    {
      Hitbox[] hitboxes = this._hitboxesActive[groupId];
      for (int i = 0; i < hitboxes.Length; i++)
      {
        hitboxes[i].gameObject.GetComponent<Collider>().enabled = value;
      }
    }

    /// <summary>
    /// Try to get an active group of hitboxes.
    /// </summary>
    public Hitbox[] GetActiveGroup(string groupId) => this._hitboxesActive[groupId];

    #endregion

    #region MonoBehaviour Messages

    protected void Awake()
    {
      // convert hitboxes into a dictionary
      this._hitboxGroupsData = this.hitboxGroups.ToDictionary((i) => i.Id, (i) => i);
    }

    protected void OnDrawGizmosSelected()
    {
      for (int i = 0; i < this.hitboxGroups.Count; i++)
      {
        HitboxDataGroup iGroup = this.hitboxGroups[i];

        // TODO: convert HitboxGroups into a reorderable list so can get selected, and only draw selected

        // iterate hitboxes in group
        for (int j = 0; j < iGroup.HitboxDatas.Count; j++)
        {
          HitboxData jData = iGroup.HitboxDatas[j];

          //UnityEngine.Debug.Log($"{i}, {j}");

          Vector3 position = jData.Parent.TransformPoint(jData.LocalPosition);

          switch (jData.Shape)
          {
            case Shape.Sphere: Gizmos.DrawWireSphere(position, jData.Size.x); break;
            case Shape.Box: Gizmos.DrawWireCube(position, jData.Size); break;
            case Shape.Capsule: GizmoUtils.DrawWireCapsule(position, Quaternion.identity, jData.Size.x, jData.Size.y); break;
          }
        }
      }
    }

    #endregion

    #region Fields

    /// <summary>
    /// HitboxData, stored into a dictionary.
    /// key: HitboxDataCollection.Id.
    /// value: Hitbox entities.
    /// </summary>
    private IDictionary<string, Hitbox[]> _hitboxesActive = new Dictionary<string, Hitbox[]>();

    /// <summary>
    /// HitboxData, stored into a dictionary.
    /// key: HitboxDataCollection.Id.
    /// value: HitboxDataCollection.Hitboxes.
    /// </summary>
    private IDictionary<string, HitboxDataGroup> _hitboxGroupsData;

    #endregion

    #region Inspector / Prefabs

    /// <summary>
    /// HitboxDataGroups, which will be cached to a dictionary.
    /// </summary>
    [SerializeField] private List<HitboxDataGroup> hitboxGroups = new List<HitboxDataGroup>();

    #endregion
  }
}