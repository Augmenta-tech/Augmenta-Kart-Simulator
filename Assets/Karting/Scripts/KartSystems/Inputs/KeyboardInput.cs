using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public KartController.Controller controller = KartController.Controller.None;

        public override InputData GenerateInput() {

            if (controller == KartController.Controller.None) {

				return new InputData {
					Accelerate = false,
					Brake = false,
					TurnInput = 0
				};

			} else {

                return new InputData {
                    Accelerate = controller == KartController.Controller.Primary ? Input.GetKey(KeyCode.Z) : Input.GetKey(KeyCode.UpArrow),
                    Brake = controller == KartController.Controller.Primary ? Input.GetKey(KeyCode.S) : Input.GetKey(KeyCode.DownArrow),
                    TurnInput = controller == KartController.Controller.Primary ? Input.GetAxis("Horizontal2") : Input.GetAxis("Horizontal")
                };
            }
        }
    }
}
