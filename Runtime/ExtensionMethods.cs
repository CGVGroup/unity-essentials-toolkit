using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cgvg.EssentialsToolkit
{
    public static class ExtensionMethods
    {
        #region TRANSFORM
        public static Transform GetChildRecursive(this Transform t, string name)
        {
            int numChildren = t.childCount;
            for (int i = 0; i < numChildren; ++i)
            {
                Transform child = t.GetChild(i);
                if (child.name == name)
                {
                    return child;
                }

                Transform foundIt = child.GetChildRecursive(name);
                if (foundIt != null)
                {
                    return foundIt;
                }
            }

            return null;
        }

        public static Transform ApplyPositionRotation(this Transform t, PositionRotation positionRotation,
            bool global = true)
        {
            if (global)
            {
                t.position = positionRotation.Position;
                t.rotation = positionRotation.Rotation;
            }
            else
            {
                t.localPosition = positionRotation.LocalPosition;
                t.localRotation = positionRotation.LocalRotation;
            }

            return t;
        }
        #endregion

        #region GAME OBJECT
        public static GameObject EnableAllRenderers(this GameObject go, bool enable)
        {
            Renderer[] renderers = go.GetComponentsInChildren<Renderer>(true);
            if (renderers == null)
                return go;

            for (int i = 0; i < renderers.Length; i++)
                renderers[i].enabled = enable;

            return go;
        }
        #endregion
        
        #region MONO BEHAVIOUR

        public static MonoBehaviour EnableAllRenderers(this MonoBehaviour mb, bool enable)
        {
            if (mb.gameObject == null)
                return mb;

            Renderer[] renderers = mb.gameObject.GetComponentsInChildren<Renderer>(true);
            if (renderers == null)
                return mb;

            for (int i = 0; i < renderers.Length; i++)
                renderers[i].enabled = enable;

            return mb;
        }

        #endregion
        
    }
}
