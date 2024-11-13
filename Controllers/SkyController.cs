using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    //Diferença de velocidade entre a movimentação do player e do offset do céu
    //para efeito de profundidade
    public float parallax = 2f;

    //Componente mesh do Quad onde se encontra o material do céu
    MeshRenderer mesh;

    //Referência do material da textura
    Material texture;

    //Vetor do offset a ser movimentado
    Vector2 offset;

    void Start()
    {
        //Referenciação dos componentes declarados
        mesh = GetComponent<MeshRenderer>();
        texture = mesh.material;
    }


    void Update()
    {
        //Pega o valor atual de offset da textura do objeto
        offset = texture.mainTextureOffset;

        //Altera o valor conforme sua movimentação / por sua escala e pelo parallax
        //para uma sensação de profundidade e tamanho mais realista
        offset.x = transform.position.x / transform.localScale.x / parallax;
        offset.y = transform.position.y / transform.localScale.y / parallax;

        //Atualiza o valor de offset da textura do objeto
        texture.mainTextureOffset = offset;
    }
}
