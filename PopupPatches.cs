using HarmonyLib;
using UnityEngine;

[HarmonyPatch]
public static class ResizePopupPatches
{
    private const float Scale = 0.5f;
    private const float RightShift = 200f;
    // Vanilla spawn X is -300; only nudge while still on the far-left spawn side.
    private const float SpawnXThreshold = -200f;

    [HarmonyPatch(typeof(UpgradePopup), "Update")]
    [HarmonyPostfix]
    private static void UpgradePopup_Update_Postfix(UpgradePopup __instance)
    {
        if (__instance == null)
            return;

        bool enabled = SparrohPlugin.resizePopups != null && SparrohPlugin.resizePopups.Value;

        if (!enabled)
        {
            __instance.transform.localScale = Vector3.one;
            return;
        }

        __instance.transform.localScale = new Vector3(Scale, Scale, 1f);

        RectTransform rt = __instance.RectTransform;
        Vector2 pos = rt.anchoredPosition;

        // Apply a one-time right shift after spawn. GameManager only rewrites Y afterward,
        // and the close animation moves X toward +350, so leave X alone once shifted.
        if (pos.x < SpawnXThreshold)
        {
            rt.anchoredPosition = new Vector2(pos.x + RightShift, pos.y);
        }
    }
}
