using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace YG 
{
    public class BannerYG : MonoBehaviour
    {
        public enum RTBNumber { One, Two, Three, Four };
        [Tooltip("Всего доступно четыре баннера. Выберите номер данного баннера")]
        public RTBNumber RTB_Number;

        RectTransform rt;

        private void Awake()
        {
#if !UNITY_EDITOR
            rt = transform.GetChild(0).GetComponent<RectTransform>();
            rt.GetComponent<RawImage>().color = Color.clear;
#endif
        }

#if !UNITY_EDITOR
        Vector2 ScreenSize;

        private void OnEnable()
        {
            YandexGame.GetDataEvent += ActivityRTB;

            if (YandexGame.SDKEnabled)
                ActivityRTB();
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= ActivityRTB;
            ActivityRTB(false);
        }

        private void Update()
        {
            if (ScreenSize.x != Screen.width || ScreenSize.y != Screen.height)
            {
                RecalculateRect();
            }

            ScreenSize.x = Screen.width;
            ScreenSize.y = Screen.height;
        }
#endif

        public void RecalculateRect()
        {
            if (!rt)
                rt = transform.GetChild(0).GetComponent<RectTransform>();

            string _width = rt.rect.width.ToString() + "px";
            string _height = rt.rect.height.ToString() + "px";
            string _left = "50%";
            string _right = "0px";
            string _top = "50%";
            string _bottom = "0px";

            string _offsetX = rt.localPosition.x.ToString();
            string _offsetY = (-rt.localPosition.y).ToString();
            string _offset = $"translate({_offsetX.Replace(",", ".")}px, {_offsetY.Replace(",", ".")}px)";

            if (RTB_Number == BannerYG.RTBNumber.One)
            {
                RecalculateRTB1(
                    _width.Replace(",", "."),
                    _height.Replace(",", "."),
                    _left.Replace(",", "."),
                    _right.Replace(",", "."),
                    _top.Replace(",", "."),
                    _bottom.Replace(",", "."),
                    _offset);
            }
            else if (RTB_Number == BannerYG.RTBNumber.Two)
            {
                RecalculateRTB2(
                    _width.Replace(",", "."),
                    _height.Replace(",", "."),
                    _left.Replace(",", "."),
                    _right.Replace(",", "."),
                    _top.Replace(",", "."),
                    _bottom.Replace(",", "."),
                    _offset);
            }
            else if (RTB_Number == BannerYG.RTBNumber.Three)
            {
                RecalculateRTB3(
                    _width.Replace(",", "."),
                    _height.Replace(",", "."),
                    _left.Replace(",", "."),
                    _right.Replace(",", "."),
                    _top.Replace(",", "."),
                    _bottom.Replace(",", "."),
                    _offset);
            }
            else if (RTB_Number == BannerYG.RTBNumber.Four)
            {
                RecalculateRTB4(
                    _width.Replace(",", "."),
                    _height.Replace(",", "."),
                    _left.Replace(",", "."),
                    _right.Replace(",", "."),
                    _top.Replace(",", "."),
                    _bottom.Replace(",", "."),
                    _offset);
            }
        }

        public void ActivityRTB(bool state)
        {
            if (RTB_Number == BannerYG.RTBNumber.One)
            {
                ActivityRTB1(state);
            }
            else if (RTB_Number == BannerYG.RTBNumber.Two)
            {
                ActivityRTB2(state);
            }
            else if (RTB_Number == BannerYG.RTBNumber.Three)
            {
                ActivityRTB3(state);
            }
            else if (RTB_Number == BannerYG.RTBNumber.Four)
            {
                ActivityRTB4(state);
            }

            if (state)
                RecalculateRect();
        }

        void ActivityRTB() => ActivityRTB(true);

        [DllImport("__Internal")]
        private static extern void RecalculateRTB1(
            string width,
            string height,
            string left,
            string right,
            string top,
            string bottom,
            string offset);

        [DllImport("__Internal")]
        private static extern void RecalculateRTB2(
            string width,
            string height,
            string left,
            string right,
            string top,
            string bottom,
            string offset);

        [DllImport("__Internal")]
        private static extern void RecalculateRTB3(
            string width,
            string height,
            string left,
            string right,
            string top,
            string bottom,
            string offset);

        [DllImport("__Internal")]
        private static extern void RecalculateRTB4(
            string width,
            string height,
            string left,
            string right,
            string top,
            string bottom,
            string offset);


        [DllImport("__Internal")]
        private static extern void ActivityRTB1(bool state);

        [DllImport("__Internal")]
        private static extern void ActivityRTB2(bool state);

        [DllImport("__Internal")]
        private static extern void ActivityRTB3(bool state);

        [DllImport("__Internal")]
        private static extern void ActivityRTB4(bool state);
    }
}
