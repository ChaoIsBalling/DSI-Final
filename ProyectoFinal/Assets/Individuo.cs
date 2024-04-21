using UnityEngine;
using System;

namespace ProyectoFinal_namespace
{
    public class Individuo
    {
        public event Action Cambio;

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value != apellido)
                {
                    apellido = value;
                    Cambio?.Invoke();
                }
            }
        }

        private int ataque;

        public int Ataque
        {
            get { return ataque; }
            set
            {
                if(value != ataque)
                {
                    ataque = value;
                    Cambio?.Invoke();
                }
            }
        }

        private int defensa;

        public int Defensa
        {
            get { return defensa; }
            set
            {
                if (value != defensa)
                {
                    defensa = value;
                    Cambio?.Invoke();
                }
            }
        }

        public Individuo(string nombre, string apellido, int ataque, int defensa)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.ataque = ataque;
            this.defensa = defensa;
        }
    }
}
