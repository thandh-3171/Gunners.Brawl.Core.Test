using System;
using System.Collections.Generic;
using UnityEngine;
using WeAreProStars.Core.Manage;
using MEC;

public class ScrollViewManagerTest : MonoBehaviour
{
    public List<FakeData> datas = new List<FakeData>()
    {
        new FakeData("ABC"),
        new FakeData("DEF")
    };

    private void Start()
    {
        Timing.RunCoroutine(_Start());
    }

    private IEnumerator<float> _Start()
    {
        var content = GetComponent<UIContentAbstract>();
        if (content == null) yield break;
        yield return Timing.WaitUntilTrue(() => content.initialized);
        datas.ForEach(data => content.AddItem<FakeData>(data));
    }
}

[Serializable]
public class FakeData
{
    public string title;

    public FakeData(string title)
    {
        this.title = title;
    }
}
