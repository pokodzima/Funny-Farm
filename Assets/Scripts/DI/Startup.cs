using System.Linq;
using Camera;
using Character;
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
        [SerializeField] private FarmTileFactory farmTileFactory;
        [SerializeField] private FarmerCharacter farmerCharacter;
        [SerializeField] private ResetCameraButton resetCameraButton;
        [SerializeField] private ScoreManager scoreManager;

        private void Awake()
        {
            farmTileFactory.Inject(seedingCanvas);
            farmTileFactory.Inject(cameraController);
            farmTileFactory.Inject(farmerCharacter);
            farmTileFactory.Inject(scoreManager);
            farmTileFactory.PlantTiles();

            foreach (var button in seedingButtons)
            {
                button.Inject(seedingCanvas);
                button.Inject(farmerCharacter);
            }

            seedingCanvas.Inject(cameraController);
            clicker.Inject(seedingCanvas);
            clicker.Inject(cameraController);

            resetCameraButton.Inject(cameraController);
        }
    }
}