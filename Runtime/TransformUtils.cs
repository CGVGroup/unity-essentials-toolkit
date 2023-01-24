using UnityEngine;

namespace cgvg.EssentialsToolkit
{
    public class PositionRotation
    {
        public Vector3 Position { get; }
        public Vector3 LocalPosition { get; }
        public Quaternion Rotation { get; }
        public Quaternion LocalRotation { get; }

        public PositionRotation(Transform transform)
        {
            Position = transform.position;
            LocalPosition = transform.localPosition;
            Rotation = transform.rotation;
            LocalRotation = transform.localRotation;
        }
    }

    public static class TransformUtils
    {
    }
}
