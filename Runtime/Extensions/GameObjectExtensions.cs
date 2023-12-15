using UnityEngine;

namespace GameUtils
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();

            if (component == default)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }


        public static bool HasAnyComponentOfTypes(this GameObject gameObject, System.Type[] componentTypes)
        {
            for (int i = 0; i < componentTypes.Length; ++i)
            {
                if (gameObject.GetComponentInChildren(componentTypes[i]) != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool TryGetAnyComponentOfTypes(this GameObject gameObject, System.Type[] componentTypes,
            out Component component)
        {
            component = null;

            for (int i = 0; i < componentTypes.Length; ++i)
            {
                component = gameObject.GetComponentInChildren(componentTypes[i]);
                if (component != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static Bounds GetBounds(this GameObject gameObject, bool includeHierarchy = true)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0)
                return new Bounds(gameObject.transform.position, Vector3.zero);

            Bounds bounds = renderers[0].bounds;

            if (includeHierarchy)

            {
                for (int i = 1; i < renderers.Length; i++)
                {
                    bounds.Encapsulate(renderers[i].bounds);
                }
            }
            
            return bounds;
        }

        public static void SetLayerRecursive(this GameObject gameObject, int layer)
        {
            foreach (Transform transform in gameObject.GetComponentsInChildren<Transform>())
            {
                transform.gameObject.layer = layer;
            }

            gameObject.layer = layer;
        }
    }
}