using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Perceptron;

namespace ANNGUI
{
	public class TrainingResW:Form
	{
		ListView lv;

		public TrainingResW (List<SampleTraining> ls)
		{
			Width = 500;
			lv = new ListView ();
			lv.Top = 10;
			lv.Left = 10;
			lv.Width = Width - 30;
			lv.Height = Height - 40;
			lv.View = View.List;
			lv.AutoResizeColumns (ColumnHeaderAutoResizeStyle.ColumnContent);
			for (int i = 0; i != ls.Count; i++) {
				lv.Items.Add (ls [i].ToString ());
			}

			Controls.Add (lv);
		}
	}
}

