using UnityEngine;
using UnityEditor;

namespace FourFangStudios.DragonAdventure
{
  /// <summary>
  /// Sourced from https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/.
  /// </summary>
  [CustomPropertyDrawer(typeof(Layer))]
  public class LayerDrawer : PropertyDrawer
  {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      SerializedProperty layerProp = property.FindPropertyRelative("m_layer");
      layerProp.intValue = EditorGUI.LayerField(position, label, layerProp.intValue);
    }
  }

}