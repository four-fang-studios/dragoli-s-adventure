using System;
using FourFangStudios.DragonAdventure.Hitboxes;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Projectiles
{
  public class BreathBurst : MonoBehaviour
  {
    #region Methods / Public

    public ElementType BreathType
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

    protected void Reset()
    {
      this.hitboxesDestroy = this.gameObject.GetComponentsInChildren<Hitbox>();
    }

    protected void Awake()
    {
      foreach (Hitbox iHitbox in this.hitboxesDestroy)
      {
        iHitbox.OnEntered.AddListener(this.hitboxOnEnteredHandler);
      }
    }

    protected void Start()
    {
      DestroyObjectDelayed(); // start countdown
    }

    #endregion

    #region Inspector / Breath

    /// <summary>
    /// Type of breath.
    /// </summary>
    [SerializeField] private ElementType breathType;

    /// <summary>
    /// Hitboxes which, when colliding with another hitbox, will destroy this GameObject.
    /// </summary>
    [SerializeField] private Hitbox[] hitboxesDestroy;

    #endregion
  }
}


