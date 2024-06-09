//  DebugLogger


using Godot;

namespace Leguar.TotalJSON.Internal {

	internal static class DebugLogger {

		internal static void LogUserWarning(string str) {
			GD.Print("TotalJSON: Warning: " + str);
		}

		internal static void LogInternalError(string str) {
			GD.PrintErr("Leguar.TotalJSON: Internal error: " + str);
		}

	}

}
