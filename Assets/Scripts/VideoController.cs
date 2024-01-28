using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private int sceneIndexOnFinishVideo;
    public VideoPlayer videoPlayer;

    private void OnEnable()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }
    private void OnDisable()
    {
        videoPlayer.loopPointReached -= OnVideoFinished;
    }
    private void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneIndexOnFinishVideo);
    }
}
