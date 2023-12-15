using System.Collections.Generic;


public static class IListExtensions
{
    public static T RandomElementWithUnityRandom<T>(this IList<T> array)
    {
        if (array.Count == 0)
        {
            return default(T);
        }

        return array[UnityEngine.Random.Range(0, array.Count)];
    }

    public static void RandomizePositionsWithUnityRandom<T>(this IList<T> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            T element = array[i];
            array.RemoveAt(i);

            int newPosition = UnityEngine.Random.Range(0, array.Count);
            array.Insert(newPosition, element);
        }
    }
}