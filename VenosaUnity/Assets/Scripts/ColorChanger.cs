using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class ColorChanger : MonoBehaviour
{
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        StartCoroutine(GetColor());

    }

    
    //Função para pegar a cor do servidor
    IEnumerator GetColor()
    {
        while (true)
        {
            string url = "http://localhost:3000/color"; //Caso tenha mudado a porta no arquivo serve.js deverá mudar aqui também.
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string colorHex = request.downloadHandler.text;
                Color newColor;
                if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
                {
                    cubeRenderer.material.color = newColor;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
