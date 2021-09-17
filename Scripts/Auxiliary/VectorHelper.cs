using UnityEngine;

public static class VectorHelper
{
    public static float GetVectorsDistance(Vector3 firstPosition, Vector3 secondPosition)
    {
        Vector3 distanceBetweenPoints;
        
        distanceBetweenPoints.x = GetDistanceBetweenPoints(firstPosition.x, secondPosition.x);
        distanceBetweenPoints.z = GetDistanceBetweenPoints(firstPosition.z, secondPosition.z);

        var distance = GetHypotenuse(distanceBetweenPoints.x, distanceBetweenPoints.z);

        return Mathf.Abs(distance);
    }

    public static float GetDistanceBetweenPoints(float firstPoint, float secondPoint)
    {
        var maxPoint = Mathf.Max(firstPoint, secondPoint);
        var minPoint = Mathf.Min(firstPoint, secondPoint);

        var distance = maxPoint - minPoint;

        return distance;
    }

    private static float GetHypotenuse(float firstSide, float secondSide)
    {
        var firstSideSquared = Mathf.Pow(firstSide, 2f);
        var secondSideSquared = Mathf.Pow(secondSide, 2f);

        var squaredHypotenuse = firstSideSquared + secondSideSquared;
        var hypotenuse = Mathf.Sqrt(squaredHypotenuse);

        return hypotenuse;
    }
}
