using UnityEngine;
using FourFangStudios.DragonAdventure.Hitboxes;

namespace FourFangStudios.DragonAdventure.Debug.Hitboxes0
{
  /// <summary>
  /// Agent for debugging the HitboxSetController.
  /// </summary>
  public class AgentEnemy : MonoBehaviour
  {
    protected void Start()
    {
      // setup defensive hitboxes
      this.hitboxesOffensive.CreateHitboxGroup("offense");
    }

    protected void Update()
    {
      this.hurtballRotate();
    }

    protected void hurtballRotate()
    {
      this.hurtball.transform.RotateAround(this.transform.position, Vector3.up, 60 * Time.deltaTime);
    }

    [SerializeField] private HitboxGroupController hitboxesOffensive;

    [SerializeField] private GameObject hurtball;
  }
}