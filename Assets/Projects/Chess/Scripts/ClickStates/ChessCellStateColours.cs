using UnityEngine;

public static class ChessCellStateColours
{
    public static Color SelectedCellColour => new Color(1, 1, 0, 0.8f);
    public static Color LegalMoveCellColour => new Color(0, 1, 0, 0.8f);
    public static Color LegalCaptureCellColour => new Color(1, 0, 0, 0.8f);
    public static Color InactiveCellColour => Color.clear;
}
