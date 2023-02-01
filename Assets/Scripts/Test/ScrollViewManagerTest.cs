using System;
using System.Collections.Generic;
using UnityEngine;
using WeAreProStars.Core.Manage;
using MEC;
using WeAreProStars.Core.Manage.UI.Template;

public class ScrollViewManagerTest : MonoBehaviour
{
    public List<FakeData> datas = new List<FakeData>()
    {
        new FakeData("ABC"),
        new FakeData("DEF")
    };

    [SerializeField] ScrollViewTemplate content;

    private void Start()
    {
        Timing.RunCoroutine(_Start());
    }

    private IEnumerator<float> _Start()
    {
        if (content == null) yield break;
        yield return Timing.WaitUntilTrue(() => content.Lived());
        yield return Timing.WaitUntilTrue(() => !content.IsBusy() && content.initialized);
        datas.ForEach(data => content.AddQueueItem<FakeData>(data));
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
