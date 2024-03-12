using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SmoothFillingBar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _fillingTimeInSeconds;

        private Coroutine _filling;

        public void Apply(float value)
        {
            StopFillingIfNeeded();
            _image.fillAmount = value;
        }

        public void SmoothFillTo(float amount)
        {
            StopFillingIfNeeded();
            _filling = StartCoroutine(Filling(amount, _fillingTimeInSeconds));
        }

        private void StopFillingIfNeeded()
        {
            if (_filling != null)
                StopCoroutine(_filling);
            _filling = null;
        }

        private IEnumerator Filling(float targetFillAmount, float timeInSeconds)
        {
            var currentValue = _image.fillAmount;
            var t = 0f;
            while (t < timeInSeconds)
            {
                t += Time.deltaTime;
                _image.fillAmount = Mathf.Lerp(currentValue, targetFillAmount, t / timeInSeconds);
                yield return null;
            }
        }
    }
}