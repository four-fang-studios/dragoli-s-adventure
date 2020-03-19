using UnityEditor;
using UnityEngine;

namespace FourFangStudios.DragonAdventure
{
  /// <summary>
  /// 
  /// </summary>
  public static class GizmoUtils
  {
    /// <summary>
    /// https://forum.unity.com/threads/drawing-capsule-gizmo.354634/
    /// </summary>
    public static void DrawWireCapsule(Vector3 position, Quaternion rotation, float radius, float height, Color color = default(Color))
    {
      if (color != default(Color))
        Handles.color = color;
      Matrix4x4 angleMatrix = Matrix4x4.TRS(position, rotation, Handles.matrix.lossyScale);
      using (new Handles.DrawingScope(angleMatrix))
      {
        var pointOffset = (height - (radius * 2)) / 2;

        //draw sideways
        Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.left, Vector3.back, -180, radius);
        Handles.DrawLine(new Vector3(0, pointOffset, -radius), new Vector3(0, -pointOffset, -radius));
        Handles.DrawLine(new Vector3(0, pointOffset, radius), new Vector3(0, -pointOffset, radius));
        Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.left, Vector3.back, 180, radius);
        //draw frontways
        Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.back, Vector3.left, 180, radius);
        Handles.DrawLine(new Vector3(-radius, pointOffset, 0), new Vector3(-radius, -pointOffset, 0));
        Handles.DrawLine(new Vector3(radius, pointOffset, 0), new Vector3(radius, -pointOffset, 0));
        Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.back, Vector3.left, -180, radius);
        //draw center
        Handles.DrawWireDisc(Vector3.up * pointOffset, Vector3.up, radius);
        Handles.DrawWireDisc(Vector3.down * pointOffset, Vector3.up, radius);

      }
    }
  }
}