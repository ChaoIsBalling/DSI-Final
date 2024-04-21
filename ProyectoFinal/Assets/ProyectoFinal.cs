using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_namespace
{
    public class ProyectoFinal : MonoBehaviour
    {
        VisualElement botonCrear;
        Toggle toggleModificar;
        VisualElement contenedor_dcha;
        TextField input_nombre;
        TextField input_apellido;
        Individuo individuoSelec;
        List<Individuo> lista_individuos = new List<Individuo>();
        Label titulo;
        IntegerField input_ataque;
        IntegerField input_defensa;

        bool userSelect = false;

        VisualElement parrot;
        VisualElement penguin;
        VisualElement walrus;
        VisualElement miTarjeta;
        Sprite img_parrot;
        Sprite img_penguin;
        Sprite img_walrus;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            contenedor_dcha = root.Q<VisualElement>("Dcha");
            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");
            botonCrear = root.Q<Button>("BotonCrear");
            toggleModificar = root.Q<Toggle>("ToggleModificar");

            parrot = root.Q<VisualElement>("parrot");
            penguin = root.Q<VisualElement>("penguin");
            walrus = root.Q<VisualElement>("walrus");

            titulo = root.Q<Label>("Titulo");
            titulo.style.fontSize = 150;
            titulo.style.unityTextOutlineWidth = 2;
            titulo.style.unityTextOutlineColor = new Color(0f, 0f, 0f);
            titulo.text = @"<color=""white""><gradient=""Titulo"">Se Reclutan Aventureros</gradient>";

            input_ataque = root.Q<IntegerField>("InputAtaque");
            input_defensa = root.Q<IntegerField>("InputDefensa");

            img_parrot = Resources.Load<Sprite>("Imagenes/parrot");
            img_penguin = Resources.Load<Sprite>("Imagenes/penguin");
            img_walrus= Resources.Load<Sprite>("Imagenes/walrus");

            contenedor_dcha.RegisterCallback<ClickEvent>(seleccionTarjeta);
            botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
            parrot.RegisterCallback<ClickEvent>(SeleccionLoro);
            penguin.RegisterCallback<ClickEvent>(SeleccionPinguino);
            walrus.RegisterCallback<ClickEvent>(SeleccionFoca);
            input_ataque.RegisterCallback<ChangeEvent<int>>(CambioAtaque);
            input_defensa.RegisterCallback<ChangeEvent<int>>(CambioDefensa);
        }
        void SeleccionLoro(ClickEvent evt)
        {
            if (userSelect && toggleModificar.value)
            {
                VisualElement foto = miTarjeta.Q("cabeza");
                foto.style.backgroundImage = new StyleBackground(img_parrot);
            }
        }
        void SeleccionPinguino(ClickEvent evt)
        {
            if (userSelect && toggleModificar.value)
            {
                VisualElement foto = miTarjeta.Q("cabeza");
                foto.style.backgroundImage = new StyleBackground(img_penguin);
            }
        }
        void SeleccionFoca(ClickEvent evt)
        {
            if (userSelect && toggleModificar.value)
            {
                VisualElement foto = miTarjeta.Q("cabeza");
                foto.style.backgroundImage = new StyleBackground(img_walrus);
            }
        }

        void NuevaTarjeta(ClickEvent evt)
        {
            if (!toggleModificar.value&&lista_individuos.Count()<10)
            {
                userSelect = true;
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                VisualElement tarjetaPlantilla = plantilla.Instantiate();
                miTarjeta = tarjetaPlantilla;

                contenedor_dcha.Add(tarjetaPlantilla);
                tarjeta_borde_negro();
                tarjeta_borde_blanco(tarjetaPlantilla);

                Individuo individuo = new Individuo(input_nombre.value, input_apellido.value, input_ataque.value, input_defensa.value);
                Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);
                individuoSelec = individuo;

                lista_individuos.Add(individuo);
            }
        }

        void seleccionTarjeta(ClickEvent e)
        {
            miTarjeta = e.target as VisualElement;
            individuoSelec = miTarjeta.userData as Individuo;
            Debug.Log(individuoSelec.Nombre);
            input_nombre.SetValueWithoutNotify(individuoSelec.Nombre);
            input_apellido.SetValueWithoutNotify(individuoSelec.Apellido);
            input_ataque.SetValueWithoutNotify(individuoSelec.Ataque);
            input_defensa.SetValueWithoutNotify(individuoSelec.Defensa);
            toggleModificar.value = true;

            tarjeta_borde_negro();
            tarjeta_borde_blanco(miTarjeta);
        }

        void CambioNombre(ChangeEvent<string> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Nombre = evt.newValue;
            }
        }

        void CambioApellido(ChangeEvent<string> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Apellido = evt.newValue;
            }
        }

        void CambioAtaque(ChangeEvent<int> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Ataque = evt.newValue;
            }
        }

        void CambioDefensa(ChangeEvent<int> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Defensa = evt.newValue;
            }
        }

        void tarjeta_borde_negro()
        {
            List<VisualElement> lista_tarjetas = contenedor_dcha.Children().ToList();
            lista_tarjetas.ForEach(elem =>
            {
                VisualElement tarjeta = elem.Q("Tarjeta");

                tarjeta.style.borderBottomColor = Color.black;
                tarjeta.style.borderRightColor = Color.black;
                tarjeta.style.borderTopColor = Color.black;
                tarjeta.style.borderLeftColor = Color.black;
            });
        }

        void tarjeta_borde_blanco(VisualElement tar)
        {
            VisualElement tarjeta = tar.Q("Tarjeta");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;
        }
    }
}