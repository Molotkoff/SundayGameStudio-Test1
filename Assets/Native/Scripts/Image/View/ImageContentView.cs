using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.EventSystems;

namespace Molotkoff.Test1App
{
    [RequireComponent(typeof(Image))]
    public class ImageContentView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointerEventData, ImageContentView> OnClick;

        private Image imageView;

        private string imageURI;

        private Coroutine loadTextureCoroutine;

        private bool firstLoad = true;
        private bool hasLoaded = false;

        public Image Image => imageView;

        public static ImageContentView Create(ImageContentView prefab, string imageURI)
        {
            var instance = Instantiate(prefab);
            instance.imageURI = imageURI;

            return instance;
        }

        private void Awake()
        {
            this.imageView = GetComponent<Image>();  
        }

        private void Start()
        {
            loadTextureCoroutine = StartCoroutine(LoadTexture());
        }

        private void OnEnable()
        {
            if (!hasLoaded && !firstLoad)
            {
                if (loadTextureCoroutine != null)
                    StopCoroutine(loadTextureCoroutine);

                loadTextureCoroutine = StartCoroutine(LoadTexture());
            }
        }

        private void OnDisable()
        {
            firstLoad = false;
        }

        private IEnumerator LoadTexture()
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageURI))
            {
                yield return uwr.SendWebRequest();

                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(uwr.error);
                    yield break;
                }
                    
                var texture = DownloadHandlerTexture.GetContent(uwr);
                var spriteRect = new Rect(0, 0, texture.width, texture.height);
                var spritePivot = new Vector2(.5f, .5f);

                imageView.sprite = Sprite.Create(texture, spriteRect, spritePivot);

                this.hasLoaded = true;
            }

            yield break;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (hasLoaded)
                OnClick?.Invoke(eventData, this);
            else
            {
                StopCoroutine(loadTextureCoroutine);
                loadTextureCoroutine = StartCoroutine(LoadTexture());
            }
        }
    }
}