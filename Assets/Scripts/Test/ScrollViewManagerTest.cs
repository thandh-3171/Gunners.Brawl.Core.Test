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

    [SerializeField] ScrollViewTemplate scroll;
    [SerializeField] DropdownTemplate dropdown;

    private void Start()
    {
        if (scroll.gameObject.activeSelf) Timing.RunCoroutine(_SpreadScroll());
        if (dropdown.gameObject.activeSelf) Timing.RunCoroutine(_SpreadDropdown());
    }

    private IEnumerator<float> _SpreadScroll()
    {
        if (scroll == null) yield break;
        yield return Timing.WaitUntilTrue(() => scroll.Lived());
        yield return Timing.WaitUntilTrue(() => !scroll.IsBusy() && scroll.initialized);
        datas.ForEach(data => scroll.AddQueueItem<FakeData>(data));
    }

    private IEnumerator<float> _SpreadDropdown()
    {
        if (dropdown == null) yield break;
        yield return Timing.WaitUntilTrue(() => dropdown.Lived());
        yield return Timing.WaitUntilTrue(() => !dropdown.IsBusy() && dropdown.initialized);
        datas.ForEach(data => dropdown.AddQueueItem<FakeData>(data));
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
