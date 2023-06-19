using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan_Practica_2_FP2
{
    
    class ListaPares
    {

        private class Nodo
        {
            public Coor pos; //Posición del Nodo
            public Nodo sig; //El siguiente Nodo
        }

        Nodo lst; //1er nodo de la lista

        //Construye la clase
        public ListaPares()
        {
            lst = null;
        }

        private Nodo nodoNEsimo(int n)
        {
            Nodo node = lst;
            Nodo nEsimoNode;

            int i = 0;
            while(node.sig != null && i < n)
            {
                node = node.sig;
                i++;
            }

            nEsimoNode = node;
            return nEsimoNode;
        }

        public Coor coorNEsimo(int n)
        {
            Nodo node = nodoNEsimo(n);

            Coor nEsimoCoor = node.pos;

            return nEsimoCoor;
        }

        public void insertData(Coor p)
        {
            //Si la lista no está vacía
            if (lst != null)
            {
                Nodo node = lst;

                //Convierte node en el último Nodo y node.sig el que se tiene que asignar
                while (node.sig != null)
                {
                    node = node.sig;
                }
                //Se asigna el Nodo vacío
                node.sig = new Nodo();
                //Se coloca en el Nodo a asignar
                node = node.sig;
                //Se asigna el dato al Nodo
                node.pos = p;

                //Se vacía el siguiente Nodo
                node.sig = null;
            }

            //Si lo está
            else
            {
                lst = new Nodo();
                lst.pos = p;
                lst.sig = null;
            }
        }
    }
}

