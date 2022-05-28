using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeScenePanel
{
    // 正常に表示、非表示が行えているか確認するためにbool型
    bool ActiveChangeScenePanel(string text);
}
