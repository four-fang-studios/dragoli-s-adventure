using System;
using UnityEngine;

namespace FourFangStudios.DragonAdventure.Runtime.Actors.Player
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
    public ElementType ActiveBreathType { get; private set; } = ElementType.None;

    /// <summary>
    /// Set the breath type.
    /// </summary>
    public void SetActiveBreathType(ElementType value)
    {
      // deactive the active breath emitter, if there is one
      if (this.GetActiveBreathEmitter(out BreathEmitter breathEmitterActive))
      {
        breathEmitterActive.gameObject.SetActive(false);
      }

      // activate the new breath emitter
      switch (value)
      {
        case ElementType.None:
          break;

        case ElementType.DebugBlue:
          this.emitterBlue.gameObject.SetActive(true);

          break;

        case ElementType.DebugRed:
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
        case ElementType.None: breathEmitter = null; return false;
        case ElementType.DebugRed: breathEmitter = this.emitterRed; return true;
        case ElementType.DebugBlue: breathEmitter = this.emitterBlue; return true;
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