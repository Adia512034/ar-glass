using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CamRenderer : MonoBehaviour
{
    public RawImage image;
    private Texture2D texture;
    private JJCameraManager cameraManager;
    private FrameListener frameListener;

    private Color32[] camData;
    private byte[] camBytes;
    private GCHandle handle;
    private bool frameUpdated;
    private int width = 1280;
    private int height = 720;
    // private Stopwatch stopwatch;
    // private int frameCount = 0;
    // private bool startfirst = true;


    void Start()
    {
        texture = new Texture2D(width, height, TextureFormat.RGBA32, false, false);
        image.texture = texture;
        cameraManager = new JJCameraManager();
        frameListener = new FrameListener(onIncomingBytes);
        frameUpdated = false;

        cameraManager.SetResolutionIndex((int)JJCameraManager.Resoltion.RES_1280x720);

        cameraManager.SetCameraFrameListener(frameListener);
        cameraManager.StartCamera((int)JJCameraManager.ColorFormat.COLOR_FORMAT_RGBA);
        // stopwatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (frameUpdated)
        {
            if (frameListener.IsNativeListener)
                texture.SetPixels32(camData);
            else
                texture.SetPixelData(camBytes, 0, 4);
            texture.Apply();
            image.texture = texture;
            image.rectTransform.localScale = new Vector3(1f, -1f, 1f);


            frameUpdated = false;

            
        }
    }

    private void onIncomingBytes(in byte[] bytes, int width, int height, int format)
    {
        camBytes = bytes;
        frameUpdated = true;
    }

}