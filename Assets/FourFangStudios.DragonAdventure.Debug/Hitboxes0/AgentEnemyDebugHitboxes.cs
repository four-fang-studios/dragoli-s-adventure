using UnityEngine;
using FourFangStudios.DragonAdventure.Runtime.Actors.Common;

namespace FourFangStudios.DragonAdventure.Debug.Hitboxes0
{
  /// <summary>
  /// Agent for debugging the HitboxSetController.
  /// </summary>
  public class AgentEnemyDebugHitboxes : MonoBehaviour
  {
    protected void Start()
    {
      // setup defensive hitboxes
      this.hitboxesOffensive.SetGroupActive("offense", true);
    }

    protected void Update()
    {
      this.hurtballRotate();
    }

    protected void hurtballRotate()
    {
      this.hurtball.transform.RotateAround(this.transform.position, Vector3.up, 60 * Time.deltaTime);
    }

    [SerializeField] private HitboxController hitboxesOffensive;

    [SerializeField] private GameObject hurtball;
  }
}