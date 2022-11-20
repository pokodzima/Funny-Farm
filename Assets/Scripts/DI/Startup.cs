using System.Linq;
using Camera;
using FarmTiles;
using UI;
using UnityEngine;

namespace DI
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private SeedingCanvas seedingCanvas;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private Clicker.Clicker clicker;
        [SerializeField] private SeedingButton[] seedingButtons;

        private void Awake()
        {
            var tiles = FindObjectsOfType<FarmTileFactory>();
            foreach (var tile in tiles)
            {
                tile.Inject(seedingCanvas);
            }

            foreach (var button in seedingButtons)
            {
                button.Inject(seedingCanvas);
            }

            seedingCanvas.Inject(cameraController);
            clicker.Inject(seedingCanvas);
            clicker.Inject(cameraController);
        }
    }
}