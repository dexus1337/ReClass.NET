using System.Diagnostics.Contracts;
using System.Drawing;
using System.Text;
using ReClassNET.Controls;
using ReClassNET.Extensions;
using ReClassNET.Memory;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class CustomNode : BaseNode
	{
		public int RealSize { get; set; }

		public override int MemorySize => RealSize;

		public override void GetUserInterfaceInfo(out string name, out Image icon)
		{
			name = "Custom";
			icon = Properties.Resources.B16x16_Button_Custom;
		}

		public override Size Draw(DrawContext context, int x, int y)
		{
			Contract.Requires(context != null);

			if (IsHidden && !IsWrapped)
			{
				return DrawHidden(context, x, y);
			}

			var length = MemorySize;
			var origX = x;

			AddSelection(context, x, y, context.Font.Height);
			x = AddIconPadding(context, x);
			x = AddIconPadding(context, x);
			x = AddAddressOffset(context, x, y);
			x = AddText(context, x, y, context.Settings.TypeColor, HotSpot.NoneId, "Custom") + context.Font.Width;
			x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, "[");
			x = AddText(context, x, y, context.Settings.IndexColor, 0, length.ToString());
			x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, "]") + context.Font.Width;

			if (!IsWrapped)
			{
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NameId, Name) + context.Font.Width;
			}

			x = AddComment(context, x, y);
			DrawInvalidMemoryIndicatorIcon(context, y);
			AddContextDropDownIcon(context, y);
			AddDeleteIcon(context, y);
			return new Size(x - origX, context.Font.Height);
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			if (spot.Id == 0)
			{
				if (int.TryParse(spot.Text, out var val) && val > 0)
				{
					RealSize = val;

					GetParentContainer()?.ChildHasChanged(this);
				}
			}
		}

		public override void CopyFromNode(BaseNode node)
		{
			RealSize = node.MemorySize;
		}


		public override int CalculateDrawnHeight(DrawContext context)
		{
			return IsHidden && !IsWrapped ? HiddenHeight : context.Font.Height;
		}
	}
}
