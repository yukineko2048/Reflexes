using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelRoot
{
    Vector2 UIScreen { get; }
    Vector2 PanelHeaderScreen { get; }
    Vector2 PanelBodyScreen { get; }
    Vector2 PanelFooterScreen { get; }
}
