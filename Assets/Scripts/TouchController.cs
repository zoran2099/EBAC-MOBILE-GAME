using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{


    [SerializeField]
    private Vector2 pastPosition;    
    public float acceleration;

    
    // Update is called once per frame
    void Update()
    {
        // Deve salvar posi��o do mouse somente quando o bot�o do mouse � pressionado
        // e assim evitar salvar a posi��o do mouse quando clicar fora da tela.
        // Isso corrige o bug onde pressinar o mouse fora da tela fazia mudar
        // a posi��o do Player Controller o que geralmente jogava o Player para
        // fora da pista

        if (Input.GetMouseButtonDown(0))
        {
            //  Sendo verdadeiro no quadro em que voc� clicou com o bot�o esquerdo do mouse.
            //  Nos quadros subsequentes, mesmo se o bot�o do mouse
            //  ainda estiver pressionado, essa fun��o retornar� falso. 
            // salva a posi��o do mouse

            pastPosition = Input.mousePosition;

        } else if (Input.GetMouseButton(0)) //Isso retornar� verdadeiro em todos os quadros em que o bot�o esquerdo do mouse estiver pressionado.
        {
            
            Move( Input.mousePosition.x - pastPosition.x);
            pastPosition = Input.mousePosition;
        }



    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * acceleration;
    }

   
}
