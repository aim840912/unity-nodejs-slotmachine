using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class ImageControl : MonoBehaviour
{
    [SerializeField] private Image[] _image;
    [SerializeField] private Data _imageData;
    [SerializeField] private float _minDuration = .2f;
    [SerializeField] private float _maxDuration = .5f;
    [SerializeField] private float _stopMinDuration = 1f;
    [SerializeField] private float _stopMaxDuration = 1.5f;
    [SerializeField] private float _stopRotateTime = 0.25f;

    private float _topPoint;
    private float _bottomPoint;

    public bool IsOver { get; private set; } = false;

    private void Start()
    {
        SetDotween();
    }

    private void SetDotween()
    {
        float imageHeight = _image[0].rectTransform.rect.size.y;

        _topPoint = imageHeight;
        _bottomPoint = imageHeight * -1f;
    }

    public void Spin()
    {
        for (int i = 0; i < _image.Length; i++)
        {
            StartLoop(_image[i]);
        }
    }

    public void Stop(int[] boardNum)
    {
        StartCoroutine(StopRotate(boardNum));
    }

    #region Spin
    private void StartLoop(Image image)
    {
        IsOver = false;

        image.transform
        .DOLocalMoveY(_bottomPoint, SetDuration(_minDuration, _maxDuration), true)
        .SetEase(Ease.InCubic)
        .OnComplete(() => Loop(image));
    }

    private void Loop(Image image)
    {
        image.transform.localPosition = new Vector3(0, _topPoint, 0);
        image.transform
            .DOLocalMoveY(_bottomPoint, SetDuration(_minDuration, _maxDuration), true)
            .SetEase(Ease.Linear)
            .SetLoops(-1)
            .OnStepComplete(() => ChangeSprite(image));
    }

    private void ChangeSprite(Image image)
    {
        int imageIndex = Random.Range(0, _imageData.RollingImage.Length);
        image.sprite = _imageData.RollingImage[imageIndex];
    }

    #endregion

    #region Stop
    private IEnumerator StopRotate(int[] boardNum)
    {
        for (var i = 0; i < _image.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, _stopRotateTime));
            LoopStop(_image[i], boardNum[i]);
        }

        yield return new WaitForSeconds(1.5f);

        IsOver = true;
    }

    private void LoopStop(Image eachImage, int boardNum)
    {
        eachImage.transform.DOKill();

        eachImage.transform
         .DOLocalMoveY(_bottomPoint, SetDuration(_minDuration, _maxDuration), true)
         .SetEase(Ease.Linear)
         .OnComplete(() => TopPointToOriginPoint(eachImage, boardNum));
    }

    private void TopPointToOriginPoint(Image eachImage, int boardNum)
    {
        ChangeFinalSprite(eachImage, boardNum);
        eachImage.transform
            .DOLocalMoveY(0, SetDuration(_stopMinDuration, _stopMaxDuration), true)
            .SetEase(Ease.OutBack);
    }

    private void ChangeFinalSprite(Image eachImage, int boardNum)
    {
        eachImage.transform.localPosition = new Vector3(0, _topPoint, 0);
        eachImage.sprite = _imageData.RollingImage[boardNum];
    }

    #endregion

    private float SetDuration(float min, float max) => Random.Range(min, max);


}