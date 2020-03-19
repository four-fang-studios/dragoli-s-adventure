using UnityEngine;

namespace FourFangStudios.DragonAdventure.Runtime.Actors.Common
{
  /// <summary>
  /// Movement controller for characters.
  /// Wraps around a UnityEngine CharacterController.
  /// </summary>
  public class MovementController : MonoBehaviour
  {
    // NEGA: we may want to override this on a per character basis. eg, DragonCharacterController, BombSpikeCharacterController, etc.

    #region Methods / Public

    /// <summary>
    /// Move.
    /// </summary>
    /// <param name="inputGlobal">Input in global space.</param>
    public void SimpleMove(Vector3 inputGlobal)
    {
      this.unityCharacterController.SimpleMove(inputGlobal * this.movementSpeed);
    }

    #endregion

    #region Methods / Private

    virtual protected void updateDirection()
    {
      // face towards direction of velocity
      Vector3 velocity = this.unityCharacterController.velocity;
      velocity.y = 0;

      // face towards velocity if velocity is greater than 0
      if (velocity != Vector3.zero)
      {
        this.transform.forward = velocity;
      }
    }

    #endregion

    #region MonoBehaviour Events

    protected void Update()
    {
      this.updateDirection();
    }

    #endregion

    #region Inspector

    [SerializeField] UnityEngine.CharacterController unityCharacterController;


    [Header("Config")]

    // NEGA: we may want to store config data in a ScriptableObject, should we want assets to represent movement

    [SerializeField] float movementSpeed;

    #endregion
  }
}