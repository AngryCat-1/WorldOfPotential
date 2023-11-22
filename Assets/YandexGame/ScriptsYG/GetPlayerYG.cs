using UnityEngine;
using UnityEngine.UI;

namespace YG
{
    public class GetPlayerYG : MonoBehaviour
    {
        public Text textPlayerName;
        public ImageLoadYG imageLoadPlayerPhoto;

        private void OnEnable() => YandexGame.GetDataEvent += GetPlayerName;
        private void OnDisable() => YandexGame.GetDataEvent -= GetPlayerName;

        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                GetPlayerName();
            }
        }

        public void GetPlayerName()
        {
            if (textPlayerName != null)
                textPlayerName.text = YandexGame.playerName;

            if (imageLoadPlayerPhoto != null && YandexGame.auth)
                imageLoadPlayerPhoto.Load(YandexGame.playerPhoto);
        }
    }
}
