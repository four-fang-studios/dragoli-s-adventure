using UnityEngine;

namespace FourFangStudios.DragonAdventure.Runtime.Actors.Player
{
  /// <summary>
  /// Emits breath from this transform.
  /// </summary>
  public class BreathEmitter : MonoBehaviour
  {
    // NEGA: We may want a ScriptableObject to configure the prefab and force
    // we may also want a "base" BreathEmitter, should the emission behaviour become coupled with the BreathType
    // eg, class FireBreathEmitter : BreathEmitter 

    #region Emit

    /// <summary>
    /// Emit a burst of breath.
    /// </summary>
    public void EmitBurst()
    {
      // instantiate particle at given direction
      GameObject burst = UnityEngine.GameObject.Instantiate(this.prefabBurst, this.transform.position, Quaternion.identity);

      // add force to the breath
      Rigidbody rigidbody = burst.GetComponent<Rigidbody>();
      rigidbody.AddForce(
        this.transform.forward * this.burstForce,
        ForceMode.Impulse
      );
    }

    #endregion

    #region Inspector / Prefabs

    [Header("Burst Prefabs")]

    /// <summary>
    /// Prefab of red breath.
    /// </summary>
    [SerializeField] GameObject prefabBurst;

    #endregion

    #region Inspector / Config

    [Header("Config")]

    /// <summary>
    /// Force to apply to breath bursts.
    /// </summary>
    [SerializeField] float burstForce;

    #endregion
  }
}