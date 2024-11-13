using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Referência do objeto player
    public GameObject player;

    //Limite da movimentação
    Vector3 offset;

    void Start()
    {
        //Diferença entre a sua posição inicial e do player
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Atualização da posição da camera conforme a do player + o offset pra manter a distância 
        transform.position = player.transform.position + offset;
    }
}
