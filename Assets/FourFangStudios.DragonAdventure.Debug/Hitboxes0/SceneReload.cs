using UnityEngine;
using UnityEngine.SceneManagement;

namespace FourFangStudios.DragonAdventure.Debug.Hitboxes0
{
  public class SceneReload : MonoBehaviour
  {
    // Update is called once per frame
    protected void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        // reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
    }
  }
}