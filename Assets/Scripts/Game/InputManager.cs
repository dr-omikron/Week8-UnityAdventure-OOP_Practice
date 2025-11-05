using UnityEngine;

namespace Game
{
    public class InputManager : MonoBehaviour
    {
        private const string HorizontalMovementAxis = "Horizontal";
        private const string VerticalMovementAxis = "Vertical";

        private const KeyCode RestartKey = KeyCode.R;
        private const KeyCode UseKey = KeyCode.F;

        private const float InputDeadZone = 0.05f;

        public float XMovementInput { get; private set; }
        public float ZMovementInput { get; private set; }

        public bool IsUsing { get; private set; }
        public bool IsRestart { get; private set; }

        private void Update()
        {
            UpdateXInput();
            UpdateZInput();
            UpdateKeys();
        }
        private void UpdateXInput()
        {
            float xInput = Input.GetAxis(HorizontalMovementAxis);

            if(IsInDeadZone(xInput) == false)
                XMovementInput = xInput;
            else
                XMovementInput = 0;
        }

        private void UpdateZInput()
        {
            float yInput = Input.GetAxis(VerticalMovementAxis);

            if(IsInDeadZone(yInput) == false)
                ZMovementInput = yInput;
            else
                ZMovementInput = 0;
        }

        private void UpdateKeys()
        {
            IsUsing = Input.GetKeyDown(UseKey);
            IsRestart = Input.GetKeyDown(RestartKey);
        }

        private bool IsInDeadZone(float value) => Mathf.Abs(value) <= InputDeadZone;
    }
}
