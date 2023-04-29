using UnityEngine;
using TMPro;
public abstract class ValueControl : MonoBehaviour
{
    [SerializeField] protected TMP_Text ValueText;
    public int CurrentValue { get; set; } = 0;

    public abstract void Add();
    public abstract void Minus();
    public abstract void Max();
    public abstract void SetZero();
    public abstract void SetValueToText();

}