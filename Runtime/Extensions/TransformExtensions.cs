using System.Collections.Generic;
using UnityEngine;

namespace GameUtils
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }

        public static void SetActiveStatus(this IEnumerable<Transform> transforms, bool isActive)
        {
            foreach (Transform enableTransform in transforms)
            {
                enableTransform.gameObject.SetActive(isActive);
            }
        }

        public static Bounds GetBounds(this Transform transform)
        {
            Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0) return new Bounds();

            Bounds bounds = renderers[0].bounds;
            if (renderers.Length == 1) return bounds;

            for (int i = 1; i < renderers.Length; i++)
            {
                Renderer renderer = renderers[i];
                bounds.Encapsulate(renderer.bounds);
            }

            return bounds;
        }
        
        public static void SetLayerForAllChildren(this Transform root, int layer)
        {
            foreach (Transform child in root)
            {
                child.gameObject.layer = layer;
                child.SetLayerForAllChildren(layer);
            }
        }
    }
}