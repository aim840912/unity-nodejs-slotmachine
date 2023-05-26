using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class ImageControlRenew : MonoBehaviour
{
    [SerializeField] private Image[] _image;
    [SerializeField] private Data _imageData;
    [SerializeField] private float _minDuration = .2f;
    [SerializeField] private float _maxDuration = .5f;
    [SerializeField] private float _stopTime;

    private float _DotweenLocalMoveDuration;
    private float _topPoint;
    private float _bottomPoint;

    public bool IsOver = false;

    private void Start()
    {
        SetDotween();

        _stopTime = Random.Range(0, 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Spin();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            int[] af = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Stop(af);
        }
    }

    private void SetDotween()
    {
        float imageHeight = _image[0].rectTransform.rect.size.y;

        _topPoint = imageHeight;
        _bottomPoint = imageHeight * -1f;

        _DotweenLocalMoveDuration = Random.Range(_minDuration, _maxDuration);
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

        StartCoroutine(StopRoutine(boardNum));

    }

    #region Spin
    private void StartLoop(Image image)
    {
        IsOver = false;
        image.transform.DOLocalMoveY(_bottomPoint, Random.Range(_minDuration, _maxDuration), true)
       .SetEase(Ease.InCubic)
       .OnComplete(() => Loop(image));
    }
    private void Loop(Image image)
    {
        image.transform.localPosition = new Vector3(0, _topPoint, 0);
        image.transform
            .DOLocalMoveY(_bottomPoint, Random.Range(_minDuration, _maxDuration), true)
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
    private IEnumerator StopRoutine(int[] boardNum)
    {
        for (var i = 0; i < _image.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, 0.25f));
            LoopStop(_image[i], boardNum[i]);
        }

        IsOver = true;
    }

    private void LoopStop(Image image, int boardNum)
    {
        image.transform.DOKill();

        image.transform.DOLocalMoveY(_bottomPoint, _DotweenLocalMoveDuration, true)
       .SetEase(Ease.Linear)
       .OnComplete(() => TopPointToOriginPoint(image, boardNum));
    }

    private void TopPointToOriginPoint(Image image, int boardNum)
    {
        ChangeFinalSprite(image, boardNum);
        image.transform
            .DOLocalMoveY(0, Random.Range(1, 1.5f), true)
            .SetEase(Ease.OutBack);
    }

    private void ChangeFinalSprite(Image eachImage, int boardNum)
    {
        eachImage.transform.localPosition = new Vector3(0, _topPoint, 0);
        eachImage.sprite = _imageData.RollingImage[boardNum];
    }

    #endregion

}