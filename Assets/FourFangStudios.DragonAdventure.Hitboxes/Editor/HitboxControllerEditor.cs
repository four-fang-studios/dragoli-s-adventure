using UnityEditor;
using FourFangStudios.DragonAdventure.Hitboxes;
using Malee.Editor;
using UnityEngine;

namespace FourFangStudios.DragonAdventure
{
  //[CanEditMultipleObjects]
  [CustomEditor(typeof(HitboxController))]
  public class HitboxControllerEditor : Editor
  {
    private ReorderableList hitboxGroups;

    protected void OnEnable()
    {
      hitboxGroups = new ReorderableList(serializedObject.FindProperty("hitboxGroups"));
      hitboxGroups.getElementNameCallback += GetList3ElementName;
    }

    protected void OnSceneGUI()
    {
      serializedObject.Update();

      // for all selected HitboxDataGroup
      foreach (var iSelected in this.hitboxGroups.Selected)
      {
        // edit hitboxes within the group 
        var iSelectedHitboxDataGroup = hitboxGroups.GetItem(iSelected);

        // get HitboxDatas in HitboxDataGroup
        var hitboxDatas = iSelectedHitboxDataGroup.FindPropertyRelative(nameof(HitboxDataGroup.HitboxDatas));

        // iterate HitboxDataGroup.HitboxDatas
        for (int i = 0; i < hitboxDatas.FindPropertyRelative("array").arraySize; i++)
        {
          // get HitboxData in HitboxDataGroup.HitboxDatas
          var iHitboxData = hitboxDatas.FindPropertyRelative("array").GetArrayElementAtIndex(i);

          // get objects
          var iHitboxDataParent = (Transform)iHitboxData.FindPropertyRelative(nameof(HitboxData.Parent)).objectReferenceValue;

          // modify localPosition via handles
          var localPosition = iHitboxData.FindPropertyRelative(nameof(HitboxData.LocalPosition));
          Vector3 positionWorld = iHitboxDataParent.TransformPoint(localPosition.vector3Value); // get world position of hitbox
          Handles.Label(positionWorld, i.ToString()); // label hitbox
          Vector3 positionWorldNew = Handles.FreeMoveHandle(positionWorld, Quaternion.identity, 1, Vector3.one, Handles.RectangleHandleCap); // handle to move
          localPosition.vector3Value = iHitboxDataParent.InverseTransformPoint(positionWorldNew); // back to local space
        }
      }

      serializedObject.ApplyModifiedProperties();
    }

    private string GetList3ElementName(SerializedProperty element)
    {
      return element.FindPropertyRelative(nameof(HitboxDataGroup.Id)).stringValue ?? "Id";
    }

    public override void OnInspectorGUI()
    {
      serializedObject.Update();

      hitboxGroups.DoLayoutList();

      serializedObject.ApplyModifiedProperties();
    }
  }
}