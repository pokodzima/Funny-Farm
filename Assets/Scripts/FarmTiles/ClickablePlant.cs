using Clicker;
using UnityEngine;

namespace FarmTiles
{
    public class ClickablePlant : MonoBehaviour,IClickableBehaviour
    {
        public FarmTile FarmTile;
        public void OnClick()
        {
            print("clicked");
            FarmTile.TryMowPlant();
        }
    }
}
