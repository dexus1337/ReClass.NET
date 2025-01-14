using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ReClassNET.Util
{
	internal sealed class ColorPresetSerializer
	{
		private const string XmlRootElement = "ColorPresets";
		private const string XmlPresetElement = "Preset";

		public static readonly string PresetFilePath = Path.Combine(
			PathUtil.SettingsFolderPath,
			"ColorPresets.xml"
		);

		public static List<ColorPreset> LoadPresets()
		{
			var presets = new List<ColorPreset>();

			try
			{
				if (!File.Exists(PresetFilePath))
				{
					return presets;
				}

				using var sr = new StreamReader(PresetFilePath);
				var document = XDocument.Load(sr);
				var root = document.Root;

				foreach (var presetElement in root?.Elements(XmlPresetElement) ?? Array.Empty<XElement>())
				{
					var preset = new ColorPreset { Name = presetElement.Attribute("name")?.Value };

					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.BackgroundColor), e => preset.BackgroundColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.SelectedColor), e => preset.SelectedColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.HiddenColor), e => preset.HiddenColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.OffsetColor), e => preset.OffsetColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.AddressColor), e => preset.AddressColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.HexColor), e => preset.HexColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.TypeColor), e => preset.TypeColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.NameColor), e => preset.NameColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.ValueColor), e => preset.ValueColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.IndexColor), e => preset.IndexColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.CommentColor), e => preset.CommentColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.TextColor), e => preset.TextColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.VTableColor), e => preset.VTableColor = XElementSerializer.ToColor(e));

					presets.Add(preset);
				}
			}
			catch
			{
				// ignored
			}

			return presets;
		}

		public static void SavePresets(IEnumerable<ColorPreset> presets)
		{
			try
			{
				var document = new XDocument(
					new XElement(XmlRootElement,
						from preset in presets
						select new XElement(XmlPresetElement,
							new XAttribute("name", preset.Name),
							XElementSerializer.ToXml(nameof(ColorPreset.BackgroundColor), preset.BackgroundColor),
							XElementSerializer.ToXml(nameof(ColorPreset.SelectedColor), preset.SelectedColor),
							XElementSerializer.ToXml(nameof(ColorPreset.HiddenColor), preset.HiddenColor),
							XElementSerializer.ToXml(nameof(ColorPreset.OffsetColor), preset.OffsetColor),
							XElementSerializer.ToXml(nameof(ColorPreset.AddressColor), preset.AddressColor),
							XElementSerializer.ToXml(nameof(ColorPreset.HexColor), preset.HexColor),
							XElementSerializer.ToXml(nameof(ColorPreset.TypeColor), preset.TypeColor),
							XElementSerializer.ToXml(nameof(ColorPreset.NameColor), preset.NameColor),
							XElementSerializer.ToXml(nameof(ColorPreset.ValueColor), preset.ValueColor),
							XElementSerializer.ToXml(nameof(ColorPreset.IndexColor), preset.IndexColor),
							XElementSerializer.ToXml(nameof(ColorPreset.CommentColor), preset.CommentColor),
							XElementSerializer.ToXml(nameof(ColorPreset.TextColor), preset.TextColor),
							XElementSerializer.ToXml(nameof(ColorPreset.VTableColor), preset.VTableColor)
						)
					)
				);

				document.Save(PresetFilePath);
			}
			catch
			{
				// ignored
			}
		}

		// In ColorPresetSerializer.cs

		public static List<ColorPreset> LoadPresetsFromFile(string filePath)
		{
			var presets = new List<ColorPreset>();

			try
			{
				using var sr = new StreamReader(filePath);
				var document = XDocument.Load(sr);
				var root = document.Root;

				foreach (var presetElement in root?.Elements(XmlPresetElement) ?? Array.Empty<XElement>())
				{
					var preset = new ColorPreset { Name = presetElement.Attribute("name")?.Value };

					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.BackgroundColor), e => preset.BackgroundColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.SelectedColor), e => preset.SelectedColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.HiddenColor), e => preset.HiddenColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.OffsetColor), e => preset.OffsetColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.AddressColor), e => preset.AddressColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.HexColor), e => preset.HexColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.TypeColor), e => preset.TypeColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.NameColor), e => preset.NameColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.ValueColor), e => preset.ValueColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.IndexColor), e => preset.IndexColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.CommentColor), e => preset.CommentColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.TextColor), e => preset.TextColor = XElementSerializer.ToColor(e));
					XElementSerializer.TryRead(presetElement, nameof(ColorPreset.VTableColor), e => preset.VTableColor = XElementSerializer.ToColor(e));

					presets.Add(preset);
				}
			}
			catch
			{
				throw new Exception("Failed to load color preset file.");
			}

			return presets;
		}
	}
}