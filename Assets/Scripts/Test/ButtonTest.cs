using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeAreProStars.Core.Manage.UI.Template;
using MEC;

public class ButtonTest : ButtonTemplate
{
    [SerializeField] Text title;

    public override IEnumerator<float> Activate()
    {
        yield return Timing.WaitUntilTrue(() => this.initialized);
        Timing.RunCoroutine(base.Activate());
        Debug.Log("Activate");
    }

    public override IEnumerator<float> OnClick()
    {
        yield return Timing.WaitUntilTrue(() => this.initialized);
        Timing.RunCoroutine(base.OnClick());
        Debug.Log("Click");
    }

    public override IEnumerator<float> OnPostAdded_SetupUI<T>(T data, GameObject entity)
    {
        yield return Timing.WaitUntilTrue(() => this.initialized);
        FakeData convert = data as FakeData;
        this.title.text = convert.title;
    }
}
