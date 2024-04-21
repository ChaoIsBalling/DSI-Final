using UnityEngine;
using UnityEngine.UIElements;

public class AtaqueDefensa : VisualElement
{
    Sprite image_atq = Resources.Load<Sprite>("Imagenes/ataque");
    Sprite image_def = Resources.Load<Sprite>("Imagenes/defensa");

    VisualElement atq1 = new VisualElement();
    VisualElement atq2 = new VisualElement();
    VisualElement atq3 = new VisualElement();
    VisualElement atq4 = new VisualElement();
    VisualElement atq5 = new VisualElement();

    VisualElement def1 = new VisualElement();
    VisualElement def2 = new VisualElement();
    VisualElement def3 = new VisualElement();
    VisualElement def4 = new VisualElement();
    VisualElement def5 = new VisualElement();

    int atqEstado;
    public int AtqEstado
    {
        get => atqEstado;
        set
        {
            atqEstado = value;
            encenderImagen();
        }
    }

    int defEstado;
    public int DefEstado
    {
        get => defEstado;
        set
        {
            defEstado = value;
            encenderImagen();
        }
    }

    void encenderImagen()
    {
        atq1.style.backgroundImage = new StyleBackground(image_atq);
        atq1.style.opacity = 0.5f;
        atq2.style.backgroundImage = new StyleBackground(image_atq);
        atq2.style.opacity = 0.5f;
        atq3.style.backgroundImage = new StyleBackground(image_atq);
        atq3.style.opacity = 0.5f;
        atq4.style.backgroundImage = new StyleBackground(image_atq);
        atq4.style.opacity = 0.5f;
        atq5.style.backgroundImage = new StyleBackground(image_atq);
        atq5.style.opacity = 0.5f;

        def1.style.backgroundImage = new StyleBackground(image_def);
        def1.style.opacity = 0.5f;
        def2.style.backgroundImage = new StyleBackground(image_def);
        def2.style.opacity = 0.5f;
        def3.style.backgroundImage = new StyleBackground(image_def);
        def3.style.opacity = 0.5f;
        def4.style.backgroundImage = new StyleBackground(image_def);
        def4.style.opacity = 0.5f;
        def5.style.backgroundImage = new StyleBackground(image_def);
        def5.style.opacity = 0.5f;

        if (atqEstado > 0) { atq1.style.opacity = 1f; }
        if (atqEstado > 1) { atq2.style.opacity = 1f; }
        if (atqEstado > 2) { atq3.style.opacity = 1f; }
        if (atqEstado > 3) { atq4.style.opacity = 1f; }
        if (atqEstado > 4) { atq5.style.opacity = 1f; }

        if (defEstado > 0) { def1.style.opacity = 1f; }
        if (defEstado > 1) { def2.style.opacity = 1f; }
        if (defEstado > 2) { def3.style.opacity = 1f; }
        if (defEstado > 3) { def4.style.opacity = 1f; }
        if (defEstado > 4) { def5.style.opacity = 1f; }

    }

    public new class UxmlFactory : UxmlFactory<AtaqueDefensa, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {

        UxmlIntAttributeDescription myAtqEstado = new UxmlIntAttributeDescription { name = "atqEstado", defaultValue = 0 };
        UxmlIntAttributeDescription myDefEstado = new UxmlIntAttributeDescription { name = "defEstado", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var atq = ve as AtaqueDefensa;
            atq.AtqEstado = myAtqEstado.GetValueFromBag(bag, cc);
            Debug.Log("ataque.Estado: " + atq.AtqEstado);

            var def = ve as AtaqueDefensa;
            def.DefEstado = myDefEstado.GetValueFromBag(bag, cc);
            Debug.Log("defensa.Estado: " + def.DefEstado);
        }
    };
    public AtaqueDefensa() {
        atq1.style.width = 50;
        atq1.style.height = 50;

        atq2.style.width = 50;
        atq2.style.height = 50;

        atq3.style.width = 50;
        atq3.style.height = 50;

        atq4.style.width = 50;
        atq4.style.height = 50;

        atq5.style.width = 50;
        atq5.style.height = 50;

        def1.style.width = 50;
        def1.style.height = 50;

        def2.style.width = 50;
        def2.style.height = 50;

        def3.style.width = 50;
        def3.style.height = 50;

        def4.style.width = 50;
        def4.style.height = 50;

        def5.style.width = 50;
        def5.style.height = 50;

        hierarchy.Add(atq1);
        hierarchy.Add(atq2);
        hierarchy.Add(atq3);
        hierarchy.Add(atq4);
        hierarchy.Add(atq5);

        hierarchy.Add(def1);
        hierarchy.Add(def2);
        hierarchy.Add(def3);
        hierarchy.Add(def4);
        hierarchy.Add(def5);
    }
}
