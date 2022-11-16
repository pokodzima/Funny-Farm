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

        private void Awake()
        {
            var tiles = FindObjectsOfType<FarmTileFactory>();
            foreach (var injectable in tiles.OfType<IInjectable>())
            {
                injectable.Inject(seedingCanvas);
            }

            seedingCanvas.Inject(cameraController);
            clicker.Inject(seedingCanvas);
            clicker.Inject(cameraController);
        }
    }
}