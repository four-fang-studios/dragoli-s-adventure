using UnityEngine;

namespace FourFangStudios.DragonAdventure.Characters.Dragon
{
  /// agent of the main character
  public class Agent : MonoBehaviour
  {
    #region Controllers

    [Header("Controllers")]

    /// <summary>
    /// Controller for moving the character around.
    /// UnityEngine CharacterController.
    /// </summary>
    [SerializeField] Characters.MovementController movement;

    /// <summary>
    /// Controller for breath.
    /// </summary>
    [SerializeField] Dragon.BreathController breath;

    #endregion

    #region Config

    /// <summary>
    /// Observes input.
    /// ie, input is made relative to this transform.
    /// </summary>
    [SerializeField] Transform inputObserver;

    #endregion

    #region Input

    /// <summary>
    /// Poll the input movement.
    /// Optionally with respect to an observer.
    /// Optionally stripvertical component. 
    /// </summary>
    private Vector3 pollInputMovement(Transform observer = null, bool stripVertical = true)
    {
      // input movement
      Vector3 inputMovement = Vector2.zero;
      inputMovement.x = Input.GetAxis("Horizontal");
      inputMovement.z = Input.GetAxis("Vertical");

      // convert local input (with respect to observer) to global input
      if (observer)
      {
        inputMovement = inputObserver.TransformDirection(inputMovement);
      }

      // strip the vertical component and preserve the magnitude
      if (stripVertical)
      {
        float magnitude = inputMovement.magnitude; // magnitude of the input, which shall be preserved in stripping
        inputMovement.y = 0; // strip the y (vertical) component
        inputMovement = inputMovement.normalized * magnitude; // rescale back to original magnitude
      }

      return inputMovement;
    }

    #endregion

    #region MonoBehaviour Events

    protected void Start()
    {
      // disable breath types
      this.breath.SetActiveBreathType(BreathType.None);
    }

    protected void Update()
    {
      Vector3 inputMovementGlobal = this.pollInputMovement(this.inputObserver, true);
      this.movement.SimpleMove(inputMovementGlobal);

      // TODO: move these to input

      // if input Fire1, emit burst
      if (
        Input.GetButton("Fire1")
     && this.breath.GetActiveBreathEmitter(out BreathEmitter activeBreathEmitter)
      )
      {
        activeBreathEmitter.EmitBurst();
      }

      // if input breath switchers, switch breath
      // TODO: make axis
      if (Input.GetKeyDown(KeyCode.Alpha0))
      {
        this.breath.SetActiveBreathType(BreathType.None);
      }
      else if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        this.breath.SetActiveBreathType(BreathType.DebugRed);
      }
      else if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        this.breath.SetActiveBreathType(BreathType.DebugBlue);
      }
    }

    #endregion
  }
}
