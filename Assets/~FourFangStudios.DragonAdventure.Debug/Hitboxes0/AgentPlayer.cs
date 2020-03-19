using UnityEngine;
using FourFangStudios.DragonAdventure.Hitboxes;

namespace FourFangStudios.DragonAdventure.Debug.Hitboxes0
{
  /// <summary>
  /// Agent for debugging the HitboxController.
  /// </summary>
  public class AgentPlayer : MonoBehaviour
  {
    protected void hitboxOffenseEnable(bool doHurt)
    {
      this.hitboxesOffensive.SetGroupActive("offense", doHurt);

      foreach (Hitbox iHitbox in this.hitboxesOffensive.GetGroup("offense"))
      {
        iHitbox.gameObject.GetComponentInParent<Renderer>().material.color = doHurt ? this.colorHurt : this.colorDefault;
      }
    }

    protected void Update()
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        // enable offensive hitbxoes
        this.hitboxOffenseEnable(true);
      }
      else if (Input.GetKeyUp(KeyCode.E))
      {
        // disable offensive hitboxes
        this.hitboxOffenseEnable(false);
      }
    }

    [SerializeField] private HitboxController hitboxesOffensive;

    [SerializeField] private Color colorDefault;

    [SerializeField] private Color colorHurt;
  }
}