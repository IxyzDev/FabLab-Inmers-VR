using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
//
public class SliderVideo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler //marcar error hasta que escriban las funciones de abajo
{
    public GameObject botonPlay;
    public GameObject botonPausa;
    public GameObject botonReiniciar;
    public GameObject botonVolumen;
    public GameObject botonMute;
    public bool play;
    public bool termino;
    public VideoPlayer videoPlayer;
    public Slider barra;
    bool slide = false;
    public AudioSource audioSource;
    public Slider barraVolumen;
    // Start is called before the first frame update
    void Start ()
    {
        botonReiniciar.SetActive(false);
        videoPlayer.Play();
        videoPlayer.Pause();
    }
    public void OnPointerDown(PointerEventData a)
    {
        videoPlayer.Pause();
        slide = true;
    }

    //
    public void OnPointerUp(PointerEventData a)
    {
        if (play)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
        float frame = (float)barra.value * (float)videoPlayer.frameCount;
        videoPlayer.frame = ((long)frame);
        slide = false;
    }
    void Update()
    {
        if (slide == false)
        {
            barra.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }

        if (barra.value >= 0.99 && termino == false)
        {
            botonReiniciar.SetActive(true);
            botonPlay.SetActive(false);
            botonPausa.SetActive(false);
            termino = true;
        }

        if (barra.value == 0)
        {
            termino = false;
        }
    }

        //
    public void Volumen ()
    {
        audioSource.volume = barraVolumen.value;
    }
    public void Play()
    {
        videoPlayer.Play();
        botonPlay.SetActive(false);
        botonPausa.SetActive(true);
        play = true;
    }
    public void Pausa()
    {
        videoPlayer.Pause();
        botonPlay.SetActive(true);
        botonPausa.SetActive(false);
        play = false;
    }
    public void Reiniciar()
    {
        videoPlayer.frame = 0;
        Play();
        botonReiniciar.SetActive(false);
    }

    //

    public void Silenciar()
    {
        if (audioSource.mute)
        {
            botonMute.SetActive(false);
            botonVolumen.SetActive(true);
            audioSource.mute = false;
        }
            
        else
        {
            botonMute.SetActive(true);
            botonVolumen.SetActive(false);
            audioSource.mute = true;
        }
    }  
}