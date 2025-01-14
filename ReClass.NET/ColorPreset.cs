using System;
using System.Drawing;
using System.Xml.Serialization;

namespace ReClassNET.Util
{
	public class ColorPreset
	{
		public string Name { get; set; }
		public Color BackgroundColor { get; set; }
		public Color SelectedColor { get; set; }
		public Color HiddenColor { get; set; }
		public Color OffsetColor { get; set; }
		public Color AddressColor { get; set; }
		public Color HexColor { get; set; }
		public Color TypeColor { get; set; }
		public Color NameColor { get; set; }
		public Color ValueColor { get; set; }
		public Color IndexColor { get; set; }
		public Color CommentColor { get; set; }
		public Color TextColor { get; set; }
		public Color VTableColor { get; set; }
		public Color PluginColor { get; set; }

		public Color ClassColor { get; set; }

		public void ApplyTo(Settings settings)
		{
			settings.BackgroundColor = BackgroundColor;
			settings.SelectedColor = SelectedColor;
			settings.HiddenColor = HiddenColor;
			settings.OffsetColor = OffsetColor;
			settings.AddressColor = AddressColor;
			settings.HexColor = HexColor;
			settings.TypeColor = TypeColor;
			settings.NameColor = NameColor;
			settings.ValueColor = ValueColor;
			settings.IndexColor = IndexColor;
			settings.CommentColor = CommentColor;
			settings.TextColor = TextColor;
			settings.VTableColor = VTableColor;
			settings.ClassColor = ClassColor;
		}

		public static ColorPreset CreateFrom(Settings settings, string name)
		{
			return new ColorPreset
			{
				Name = name,
				BackgroundColor = settings.BackgroundColor,
				SelectedColor = settings.SelectedColor,
				HiddenColor = settings.HiddenColor,
				OffsetColor = settings.OffsetColor,
				AddressColor = settings.AddressColor,
				HexColor = settings.HexColor,
				TypeColor = settings.TypeColor,
				NameColor = settings.NameColor,
				ValueColor = settings.ValueColor,
				IndexColor = settings.IndexColor,
				CommentColor = settings.CommentColor,
				TextColor = settings.TextColor,
				VTableColor = settings.VTableColor,
				ClassColor = settings.ClassColor
			};
		}
	}
}