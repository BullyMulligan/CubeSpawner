using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoloring : MonoBehaviour
{
    private Color _startColor;//начальный цвет кубика на данный момент
    private Color _nextColor;//следующий цвет

    [SerializeField] private float _recoloringTime;//время, за которое цвет меняется
    [SerializeField] private float _waitingTime;//время, которое нужно подождать до следующей смены
    private Renderer _renderer;
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        NextColor();
    }

    
    void Update()
    {
        _recoloringTime += Time.deltaTime;
        var progress = _recoloringTime / _waitingTime;
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;
        
        if (_recoloringTime >= _waitingTime)//если время текущей смены цвета достигнет времени смены цвета, то
        {
            _recoloringTime = 0f;//время обнулится, начав цикл смены цвета сначала
            NextColor();//запускаем функцию смены цвета сначала
        }

    }

    private void NextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0.1f,1f,0.8f,1f,1f,1f);
    }
}
