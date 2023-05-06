using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractableTime : MonoBehaviour
{
    [SerializeField] private float _interactableTime = 2;
    private Coroutine _coroutine;
    [SerializeField] private Selectable _button;

    public void StartDelayInteractable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(SetDelayInteractableTime(_interactableTime));
    }

    IEnumerator SetDelayInteractableTime(float interactableTime)
    {
        _button.interactable = false;
        yield return new WaitForSeconds(interactableTime);
        _button.interactable = true;
        _coroutine = null;
    }
}
