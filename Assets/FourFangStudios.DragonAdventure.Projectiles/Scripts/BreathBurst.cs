using System;
using FourFangStudios.DragonAdventure.Hitboxes;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Projectiles
{
  public class BreathBurst : MonoBehaviour
  {
    #region Methods / Public

    public BreathType BreathType
    {
      get => breathType;
    }

    #endregion

    #region Destroy
    private void DestroyObjectDelayed()
    {
      Destroy(gameObject, 3);
    }

    private void hitboxOnEnteredHandler(Hitbox source, Hitbox other)
    {
      Destroy(this.gameObject);
    }

    #endregion

    #region Monobehavior Messages

    protected void Start()
    {
      // instantiate hitbox
      this._hitbox = this.hitbox.Instantiate("0");
      this._hitbox.OnEntered.AddListener(this.hitboxOnEnteredHandler);

      DestroyObjectDelayed(); // start countdown
    }

    #endregion

    #region Fields

    private Hitbox _hitbox;

    #endregion

    #region Inspector / Breath

    /// <summary>
    /// Type of breath.
    /// </summary>
    [SerializeField] private BreathType breathType;

    [SerializeField] private HitboxData hitbox;

    #endregion
  }
}


