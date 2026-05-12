#nullable enable
using System.Collections.Generic;
using System.IO;
using DeepForestLabs.EditorTools.Validation;
using UnityEditor;
using UnityEngine;

namespace GameName.Editor
{
    public static class TemplateValidationEditor
    {
        private static readonly string[] ExpectedPackages =
        {
            "com.deepforestlabs.framework",
            "com.deepforestlabs.audio",
            "com.deepforestlabs.buildsystem",
            "com.deepforestlabs.logger"
        };

        private static readonly string[] ExpectedResourceAssets =
        {
            "Assets/Resources/MainArgs.asset",
            "Assets/Resources/BuildSettings.asset"
        };

        [MenuItem("Tools/DFL/Validate Template")]
        public static void ValidateTemplate()
        {
            List<ValidationResult> results = ProjectValidator.ValidateProject();

            ValidateManifest(results);
            ValidateExpectedAssets(results);

            if (results.Count == 0)
            {
                EditorUtility.DisplayDialog("Template Validation", "All checks passed!", "OK");
                return;
            }

            ProjectValidationWindow window = EditorWindow.GetWindow<ProjectValidationWindow>("Template Validation");
            window.RunValidation();
            window.Show();
        }

        private static void ValidateManifest(List<ValidationResult> results)
        {
            string manifestPath = Path.Combine(Application.dataPath, "..", "Packages", "manifest.json");
            if (!File.Exists(manifestPath))
            {
                results.Add(new ValidationResult(
                    ValidationSeverity.Error,
                    "Packages/manifest.json not found.",
                    "Template"));
                return;
            }

            string content = File.ReadAllText(manifestPath);
            foreach (string pkg in ExpectedPackages)
            {
                if (!content.Contains(pkg))
                {
                    results.Add(new ValidationResult(
                        ValidationSeverity.Warning,
                        $"Package '{pkg}' not found in manifest.json.",
                        "Template"));
                }
            }
        }

        private static void ValidateExpectedAssets(List<ValidationResult> results)
        {
            foreach (string assetPath in ExpectedResourceAssets)
            {
                if (AssetDatabase.LoadAssetAtPath<Object>(assetPath) == null)
                {
                    results.Add(new ValidationResult(
                        ValidationSeverity.Warning,
                        $"Expected asset not found: {assetPath}",
                        "Template"));
                }
            }
        }
    }
}
#nullable disable
