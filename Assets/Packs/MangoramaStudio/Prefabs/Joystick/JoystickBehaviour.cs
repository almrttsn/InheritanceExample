using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MangoramaStudio.Scripts.Behaviours
{
    public class JoystickBehaviour : MonoBehaviour
    {
        public bool IsMovementDeactivated { get; set; }

        [SerializeField] private Transform _jParent;

        [SerializeField] private Image _joystickBgImage;
        [SerializeField] private Image _joystickInnerImage;

        private Vector2 _positionInput;
        private Vector3 _firstInput;        

        private bool _isPressing;

        private void Update()
        {
            if (IsMovementDeactivated) return;

            if (Input.GetMouseButtonDown(0))
            {
                _jParent.transform.position = Input.mousePosition;
                _isPressing = true;
                _firstInput = Input.mousePosition;

                _joystickBgImage.enabled = true;
                _joystickInnerImage.enabled = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isPressing = false;

                _positionInput = Vector2.zero;
                _joystickInnerImage.rectTransform.anchoredPosition = Vector2.zero;

                _joystickBgImage.enabled = false;
                _joystickInnerImage.enabled = false;
            }

            if (_isPressing)
            {
                _positionInput = (Input.mousePosition - _firstInput);                

                _positionInput.x /= (_joystickBgImage.rectTransform.sizeDelta.x);
                _positionInput.y /= (_joystickBgImage.rectTransform.sizeDelta.y);

                if (_positionInput.magnitude > 1.0f)
                {
                    _positionInput = _positionInput.normalized;
                }

                _joystickInnerImage.rectTransform.anchoredPosition = new Vector2(_positionInput.x * (_joystickBgImage.rectTransform.sizeDelta.x / 2),
                    _positionInput.y * (_joystickBgImage.rectTransform.sizeDelta.y / 2));
            }
        }
        public float GetHorizontalInput()
        {           
            return _positionInput.x;
        }
        public float GetVerticalInput()
        {
            return _positionInput.y;
        }
    }
}