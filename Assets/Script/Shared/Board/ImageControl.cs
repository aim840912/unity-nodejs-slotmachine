using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class ImageControl : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Data _imageData;
    [SerializeField] private float _minDuration = .2f;
    [SerializeField] private float _maxDuration = .5f;

    private float _DotweenLocalMoveDuration;
    private float _topPoint;
    private float _bottomPoint;

    private void Start()
    {
        SetDotween();
        _image = GetComponent<Image>();
    }

    private void SetDotween()
    {
        float imageHeight = _image.rectTransform.rect.size.y;

        _topPoint = imageHeight;
        _bottomPoint = imageHeight * -1f;

        _DotweenLocalMoveDuration = Random.Range(_minDuration, _maxDuration);
    }

    #region Spin
    public Tween StartLoop()
    {
        return _image.transform.DOLocalMoveY(_bottomPoint, _DotweenLocalMoveDuration, true)
        .SetEase(Ease.InCubic)
        .OnComplete(() => Loop());
    }
    void Loop()
    {
        _image.transform.localPosition = new Vector3(0, _topPoint, 0);
        _image.transform
            .DOLocalMoveY(_bottomPoint, _DotweenLocalMoveDuration, true)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .OnStepComplete(() => ChangeSprite(_image));
    }
    void ChangeSprite(Image image)
    {
        int imageIndex = Random.Range(0, _imageData.RollingImage.Length);
        image.sprite = _imageData.RollingImage[imageIndex];
    }

    #endregion

    #region Stop
    public Tween LoopStop(int boardNum)
    {
        _image.transform.DOKill();

        return _image.transform.DOLocalMoveY(_bottomPoint, _DotweenLocalMoveDuration, true)
        .SetEase(Ease.Linear)
        .OnComplete(() => TopPointToOriginPoint(boardNum));
    }

    void TopPointToOriginPoint(int boardNum)
    {
        ChangeFinalSprite(_image, boardNum);
        _image.transform
            .DOLocalMoveY(0, Random.Range(1, 1.5f), true)
            .SetEase(Ease.OutBack);
    }

    void ChangeFinalSprite(Image eachImage, int boardNum)
    {
        eachImage.transform.localPosition = new Vector3(0, _topPoint, 0);
        eachImage.sprite = _imageData.RollingImage[boardNum];
    }

    #endregion

    public IEnumerator SetTimeToStopSpin(int boardNum)
    {
        int time = Random.Range(0, 1);
        yield return new WaitForSeconds(time);
        LoopStop(boardNum);
    }

}