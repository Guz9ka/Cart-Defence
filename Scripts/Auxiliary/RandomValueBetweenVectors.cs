using UnityEngine;

public static class RandomValueBetweenVectors
{
    public static Vector3 GetRandomVectorInRange(Vector3 firstVector, Vector3 secondVector)
    {
        var x = GetRandomNumberInRange(firstVector.x, secondVector.x);
        var y = GetRandomNumberInRange(firstVector.y, secondVector.y);
        var z = GetRandomNumberInRange(firstVector.z, secondVector.z);
        
        var randomVector = new Vector3(x, y, z);
        return randomVector;
    }

    private static float GetRandomNumberInRange(float firstNumber, float secondNumber)
    {
        var randomValue = Random.Range(firstNumber, secondNumber);
        return randomValue;
    }
}
