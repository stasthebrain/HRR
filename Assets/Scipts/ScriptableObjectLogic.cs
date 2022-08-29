using UnityEngine;

[CreateAssetMenu(fileName = "New IntVariable", menuName = "IntVariable", order = 51)]

public class ScriptableObjectLogic : ScriptableObject
{
    public int Value;

    public void SetValue(int Value)
    {
        this.Value = Value;
    }
}
