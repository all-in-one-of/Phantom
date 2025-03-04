using UnityEngine;

namespace Klak.Wiring
{
    [AddComponentMenu("Klak/Wiring/Convertion/HueToColor")]
    public class HueToColor : NodeBase
    {
        #region Editable properties

        [SerializeField, Range(0, 1)]
        float _hue = 0;

        [SerializeField, Range(0, 1)]
        float _saturation = 1;

        [SerializeField]
        float _brightness = 1;

        #endregion

        #region Node I/O

        [Inlet]
        public float hue {
            set {
                _hue = value;
                if (enabled) UpdateAndInvoke();
            }
        }

        [Inlet]
        public float saturation {
            set {
                _saturation = value;
                if (enabled) UpdateAndInvoke();
            }
        }

        [Inlet]
        public float brightness {
            set {
                _brightness = value;
                if (enabled) UpdateAndInvoke();
            }
        }

        [SerializeField, Outlet]
        ColorEvent _colorEvent = new ColorEvent();

        #endregion

        #region Private members

        void UpdateAndInvoke()
        {
            _colorEvent.Invoke(Color.HSVToRGB(_hue, _saturation, _brightness));
        }

        #endregion
    }
}
