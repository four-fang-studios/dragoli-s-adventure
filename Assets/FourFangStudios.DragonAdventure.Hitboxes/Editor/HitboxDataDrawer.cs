using UnityEngine;
using UnityEditor;

namespace FourFangStudios.DragonAdventure.Hitboxes
{
  /// <summary>
  /// Drawer for HitboxData.
  /// </summary>
  [CustomPropertyDrawer(typeof(HitboxData))]
  public class HitboxDataDrawer : PropertyDrawer
  {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      Rect r1 = position;
      r1.width = 20;

      Rect r2 = position;
      r2.xMin = r1.xMax + 10;

      EditorGUI.BeginProperty(position, label, property);

      EditorGUI.ObjectField(r1, property.FindPropertyRelative(nameof(HitboxData.Parent)), typeof(Transform));
      //EditorGUILayout.ObjectField(property.FindPropertyRelative(nameof(HitboxData.Parent)))

      EditorGUI.EndProperty();
    }
  }
}