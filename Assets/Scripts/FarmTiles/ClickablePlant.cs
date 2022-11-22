using Character;
using Clicker;
using DI;
using UnityEngine;

namespace FarmTiles
{
    public class ClickablePlant : MonoBehaviour,IClickableBehaviour
    {
        public FarmTile FarmTile;
        public FarmerCharacter FarmerCharacter;
        public void OnClick()
        {
            FarmerCharacter.PickupPlant(FarmTile);
        }
    }
}
