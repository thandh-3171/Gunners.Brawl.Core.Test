using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeAreProStars.Core.Manage.UI.Template;
using MEC;

public class ButtonTest : ButtonTemplate
{
    [SerializeField] Text title;
        
    public override void Activate()
    {
        if (!initialized) return;
        base.Activate();
        Debug.Log("Activate " + title.text);
    }

    public override void OnClick()
    {
        if (!initialized) return;
        base.OnClick();
        Debug.Log("OnClick " + title.text);
    }

    public override void OnPostAdded_SetupUI<T>(T data, GameObject entity)
    {
        if (!initialized) return;
        base.OnPostAdded_SetupUI<T>(data, entity);
        FakeData convert = data as FakeData;
        this.title.text = convert.title;
    }
}
