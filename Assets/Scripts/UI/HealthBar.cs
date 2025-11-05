using Characters;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private HealthComponent _healthComponent;
        
        private Camera _camera;

        private void Start()
        {
            _slider.minValue = 0;
            _slider.maxValue = _healthComponent.MaxHealth;
            _camera = Camera.main;
        }

        private void Update()
        {
            UpdateSlider();
            RotateToCamera();
        }

        private void RotateToCamera()
        {
            Vector3 cameraDirection = (transform.position - _camera.transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(cameraDirection);
        }

        private void UpdateSlider() => _slider.value = _healthComponent.Health;
    }
}
