using UnityEngine;
using UnityEngine.UIElements;

namespace ProyectoFinal_namespace
{
    public class Tarjeta
    {
        Individuo myIndividuo;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label apellidoLabel;

        public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.myIndividuo = individuo;

            nombreLabel = tarjetaRoot.Q<Label>("Nombre");
            apellidoLabel = tarjetaRoot.Q<Label>("Apellido");
            tarjetaRoot.userData = myIndividuo;

            UpdateUI();

            myIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {
            nombreLabel.text = myIndividuo.Nombre;
            apellidoLabel.text = myIndividuo.Apellido;
        }
    }
}
