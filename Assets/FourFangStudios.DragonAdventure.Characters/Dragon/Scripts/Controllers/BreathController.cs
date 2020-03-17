using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Characters.Dragon
{
  /// <summary>
  /// Controls breath emitters.
  /// </summary>
  public class BreathController : MonoBehaviour
  {
    #region BreathType

    /// <summary>
    /// Type of the breath to emit.
    /// </summary>
    public BreathType ActiveBreathType { get; private set; } = BreathType.None;

    /// <summary>
    /// Set the breath type.
    /// </summary>
    public void SetActiveBreathType(BreathType value)
    {
      // deactive the active breath emitter, if there is one
      if (this.GetActiveBreathEmitter(out BreathEmitter breathEmitterActive))
      {
        breathEmitterActive.gameObject.SetActive(false);
      }

      // activate the new breath emitter
      switch (value)
      {
        case BreathType.None:
          break;

        case BreathType.DebugBlue:
          this.emitterBlue.gameObject.SetActive(true);

          break;

        case BreathType.DebugRed:
          this.emitterRed.gameObject.SetActive(true);

          break;

        default:
          throw new ArgumentException($"{nameof(ActiveBreathType)} '{value}' not supported! Did you add an emitter?");
      }

      // update field
      this.ActiveBreathType = value;
    }

    #endregion

    #region Emitters

    /// <summary>
    /// Get the active BreathEmitter via the ActiveBreathType.
    /// Null if BreathType.None.
    /// </summary>
    public bool GetActiveBreathEmitter(out BreathEmitter breathEmitter)
    {
      // uses a switch instead of caching a field, so that the ActiveBreathType field is the single source of truth

      switch (this.ActiveBreathType)
      {
        case BreathType.None: breathEmitter = null; return false;
        case BreathType.DebugRed: breathEmitter = this.emitterRed; return true;
        case BreathType.DebugBlue: breathEmitter = this.emitterBlue; return true;
        default: throw new ArgumentException($"{nameof(ActiveBreathType)} '{this.ActiveBreathType}' not supported! Did you add an emitter?");
      }

    }

    [Header("Emitters")]

    /// <summary>
    /// Origin of red breath.
    /// </summary>
    [SerializeField] BreathEmitter emitterRed;

    /// <summary>
    /// Origin of blue breath.
    /// </summary>
    [SerializeField] BreathEmitter emitterBlue;

    #endregion

    #region MonoBehaviour Events

    protected void Awake()
    {
      // deactivate all emitters
      this.emitterBlue.gameObject.SetActive(false);
      this.emitterRed.gameObject.SetActive(false);
    }

    #endregion
  }
}