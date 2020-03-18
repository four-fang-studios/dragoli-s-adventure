using System;
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

    private void OnCollisionEnter() 
    {
      Destroy(gameObject);
    }
    #endregion

    #region Monobehavior Events
    protected void Start() 
    {
      DestroyObjectDelayed();
    }
    #endregion

    #region Inspector / Breath

    /// <summary>
    /// Type of breath.
    /// </summary>
    [SerializeField] private BreathType breathType;

    #endregion
  }
}


