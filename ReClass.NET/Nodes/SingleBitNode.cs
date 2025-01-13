using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.IO;
using ReClassNET.Controls;
using ReClassNET.Extensions;
using ReClassNET.UI;


namespace ReClassNET.Nodes
{
	public class SingleBitNode : BaseNumericNode
	{
		public int BitStart = 0;
		public int BitCount = 1;
		public int BitCap = 8;
		public bool bParentIsBoolean = false;
		public int RemainingBits => BitCap - (BitCount + BitStart);
		private ulong MaxBits => (ulong)(1 << BitCount) - 1;
		public override int MemorySize => 1;
		public override void GetUserInterfaceInfo(out string name, out Image icon)
		{
			name = "Single Bit";
			icon = Properties.Resources.B16x16_Button_Bit1;
		}

		public override Size Draw(DrawContext context, int x, int y)
		{
			if (IsHidden && !IsWrapped)
			{
				return DrawHidden(context, x, y);
			}

			var origX = x;

			AddSelection(context, x, y, context.Font.Height);

			x = AddIconPadding(context, x);
			x = AddIconPadding(context, x);

			x = AddAddressOffset(context, x, y);

			x = AddText(context, x, y, context.Settings.TypeColor, HotSpot.NoneId, $"bit:{BitStart} -") + context.Font.Width;
			x = AddText(context, x, y, context.Settings.TypeColor, 11, $"{BitCount}") + context.Font.Width;
			if (!IsWrapped)
			{
				x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NameId, Name) + context.Font.Width;
			}
			x = AddText(context, x, y, context.Settings.NameColor, HotSpot.NoneId, "=") + context.Font.Width;

			ulong value = 0;
			switch (BitCap / 8)
			{
				case 8:
					value = context.Memory.ReadUInt64(Offset);
					break;
				case 4:
					value = context.Memory.ReadUInt32(Offset);
					break;
				case 2:
					value = context.Memory.ReadUInt16(Offset);
					break;
				case 1:
				default:
					value = context.Memory.ReadUInt8(Offset);
					break;
			}
			value = MaxBits & (value >> BitStart);
			x = AddText(context, x, y, context.Settings.ValueColor, 0, value.ToString()) + context.Font.Width;
			if (bParentIsBoolean)
				x = AddText(context, x, y, context.Settings.ValueColor, HotSpot.NoneId, value == 0 ? " (false)" : " (true)") + context.Font.Width;

			x = AddComment(context, x, y);

			DrawInvalidMemoryIndicatorIcon(context, y);
			AddContextDropDownIcon(context, y);
			AddDeleteIcon(context, y);

			return new Size(x - origX, context.Font.Height);
		}

		public override void Update(HotSpot spot)
		{
			Contract.Requires(spot != null);

			base.Update(spot);
			if (spot.Id == 11)
			{
				if (int.TryParse(spot.Text, out var val) && val <= RemainingBits + BitCount && val > 0)
				{
					BitCount = val;
				}
			}
			else if (spot.Id==0 || spot.Id==1)
			{
				var val = spot.Memory.ReadUInt64(Offset);
				if (BitCount > 1)
				{
					if (ulong.TryParse(spot.Text, out var inp) && inp <= MaxBits)
					{
						val &= ~(MaxBits << BitStart); //Clear intended bits
						val |= (inp << BitStart);
						spot.Process.WriteRemoteMemory(spot.Address + Offset, val);
					}
					return;
				}
				bool bistrue = (spot.Text == "1" || spot.Text == "true") ? true : false;
				if (bistrue)
				{
					val |= (byte)(1 << BitStart);
				}
				else
				{
					val &= (byte)~(1 << BitStart);
				}
				spot.Process.WriteRemoteMemory(spot.Address + Offset, val);

			}
		}
	}
}
