﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ANNGUI
{
	public class MainW:Form
	{
		ComboBox sel;
		NumericUpDown cN,mV, umbral, alpha;
		CheckBox bias;
		Label lN, lSel, lUmbral, lAlpha;
		ListView lsW, lsSm;
		Button bAN,bAS,bEnt,bClear;
		List<double> ws;
		List<int> els;
		List<int[]> ms;
		int elAct;
		int[] bs;

		public MainW ()
		{
			Width = 400;
			Height = 400;
			Text = "ANN";

			sel = new ComboBox ();
			sel.Top = 10;
			sel.Left = 10;
			sel.Width = 90;
			sel.Height = 20;
			sel.Items.Add ("Perceptrón");
			sel.Items.Add ("ADALINE");
			sel.SelectedIndex = 0;
			sel.SelectedIndexChanged += Sel_SelectedIndexChanged;

			lSel = new Label ();
			lSel.AutoSize = true;
			lSel.Text = "Tipo de ANN";
			lSel.Top = sel.Top;
			lSel.Left = sel.Left + sel.Width + 10;

			umbral = new NumericUpDown ();
			umbral.DecimalPlaces = 1;
			umbral.Top = sel.Top + sel.Height + 10;
			umbral.Left = sel.Left;
			umbral.Increment = 0.1m;
			umbral.Value = 0.0m;
			umbral.Width = 40;

			lUmbral = new Label ();
			lUmbral.Text = "Umbral";
			lUmbral.Left = umbral.Left + umbral.Width + 10;
			lUmbral.Top = umbral.Top;

			alpha = new NumericUpDown ();
			alpha.DecimalPlaces = 1;
			alpha.Top = umbral.Top + umbral.Height + 10;
			alpha.Left = umbral.Left;
			alpha.Increment = 0.1m;
			alpha.Value = 1.0m;
			alpha.Width = umbral.Width;

			lAlpha = new Label ();
			lAlpha.Text = "Alfa";
			lAlpha.Top = alpha.Top;
			lAlpha.Left = alpha.Left + alpha.Width + 10;

			bias = new CheckBox ();
			bias.Top = alpha.Top + alpha.Height + 10;
			bias.Left = alpha.Left;
			bias.Text = "Bias";
			bias.Checked = true;
			bias.CheckedChanged += Bias_CheckedChanged;

			lsW = new ListView ();
			lsW.Width = sel.Width;
			lsW.Height = 100;
			lsW.Top = bias.Top + bias.Height + 10;
			lsW.Left = bias.Left;
			lsW.View = View.List;

			cN = new NumericUpDown ();
			cN.Increment = 0.1m;
			cN.DecimalPlaces = 1;
			cN.Height = 30;
			cN.Width = 60;
			cN.Top = lsW.Top;
			cN.Left = lsW.Left + lsW.Width + 10;
			cN.Minimum = -1;
			cN.Maximum = 20;
			cN.Value = 0;

			lN = new Label ();
			lN.Text = "Peso de la neurona";
			lN.Top = cN.Top;
			lN.Left = cN.Left + cN.Width + 10;
			lN.AutoSize = true;

			bAN = new Button ();
			bAN.Text = "Añadir neurona";		
			bAN.AutoSize = true;
			bAN.Left = cN.Left;
			bAN.Top = cN.Top + cN.Height + 10;
			bAN.Click += BAN_Click;

			lsSm = new ListView ();
			lsSm.Left = lsW.Left;
			lsSm.Top = lsW.Top + lsW.Height + 10;
			lsSm.Height = lsW.Height;
			lsSm.Width = lsW.Width;
			lsSm.View = View.List;
			lsSm.Enabled = false;

			mV = new NumericUpDown ();
			mV.DecimalPlaces = 0;
			mV.Increment = 1;
			mV.Minimum = 0;
			mV.Width = cN.Width;
			mV.Height = cN.Height;
			mV.Top = lsSm.Top;
			mV.Left = lsSm.Left  + lsSm.Width + 10;
			mV.Enabled = false;

			bAS = new Button ();
			bAS.Text = "Añadir elemento 0";
			bAS.AutoSize = true;
			bAS.Top = mV.Top + mV.Height + 10;
			bAS.Left = mV.Left;
			bAS.Enabled = false;
			bAS.Click += BAS_Click;

			bClear = new Button ();
			bClear.AutoSize = true;
			bClear.Text = "Limpiar";
			bClear.Top = Height - bClear.Height - 50;
			bClear.Left = Width - 200;
			bClear.Enabled = false;
			bClear.Click += BClear_Click;

			bEnt = new Button ();
			bEnt.AutoSize = true;
			bEnt.Text = "Entrenar";
			bEnt.Left = bClear.Left + bClear.Width + 20;
			bEnt.Top = bClear.Top;
			bEnt.Enabled = false;
			bEnt.Click += BEnt_Click;


			Controls.Add (cN);
			Controls.Add (lN);
			Controls.Add (sel);
			Controls.Add (lSel);
			Controls.Add (lsW);
			Controls.Add (bAN);
			Controls.Add (lsSm);
			Controls.Add (bAS);
			Controls.Add (mV);
			Controls.Add (bEnt);
			Controls.Add (bClear);
			Controls.Add (umbral);
			Controls.Add (alpha);
			Controls.Add (bias);
			Controls.Add (lUmbral);
			Controls.Add (lAlpha);

			bs = new int[]{ -1, 0, 1 };
			els = new List<int> ();
			ws = new List<double> ();
			ms = new List<int[]> ();
			Limpiar ();
		}

		void Bias_CheckedChanged (object sender, EventArgs e)
		{
			Limpiar ();
		}

		void BClear_Click (object sender, EventArgs e)
		{
			Limpiar ();
		}

		void Limpiar(){
			lsW.Items.Clear ();
			els.Clear ();
			elAct = 1;
			els.Add (bias.Checked ? 1 : bs[Environment.TickCount%bs.Length]);
			els.Add (0);
			lsSm.Items.Clear ();
			lsSm.Items.Add ("((),)");
			ActLs ();
			ms.Clear ();
			ws.Clear ();
			ws.Add (0);
			bEnt.Enabled = false;
			bAS.Enabled = false;
			bClear.Enabled = false;
			lsSm.Enabled = false;
			SetInitialMV ();
		}

		void Sel_SelectedIndexChanged (object sender, EventArgs e)
		{			
			Limpiar ();
		}

		void SetInitialMV(){
			if (sel.SelectedIndex == 0) {
				mV.Minimum = 0;
				mV.Maximum = 1;
			} else {
				mV.Minimum = decimal.MinValue;
				mV.Maximum = decimal.MaxValue;
			}
		}

		void BEnt_Click (object sender, EventArgs e)
		{
			List<Perceptron.SampleTraining> ls;
			var s = new Perceptron.Sample[ms.Count];
			for (int i = 0; i != ms.Count; i++) {
				s [i] = Convert (ms [i]);
			}
			if (sel.SelectedIndex == 0) {
				ls = Perceptron.Program.SimplePerceptron ((double)alpha.Value, (double)umbral.Value, ws.ToArray (), s);
			} else {
				ls = Perceptron.Program.Adaline ((double)alpha.Value, (double)umbral.Value, ws.ToArray (), s);
			}
			var tn = new TrainingResW (ls);
			tn.Show ();
		}			

		Perceptron.Sample Convert(int[] s){
			var r = new int[s.Length - 1];
			Array.Copy (s, r, s.Length - 1);
			return new Perceptron.Sample (r, s [s.Length - 1]);
		}

		void BAS_Click (object sender, EventArgs e)
		{
			var s = (int)mV.Value;
			els [elAct] = s;
			elAct++;
			ActLs ();
			if (elAct == els.Count) {				
				elAct = 1;
				lsSm.Items.Add ("((), )");
				ActLs ();
				bAS.Text = string.Format("Añadir elemento {0}",elAct);
				SetInitialMV ();
				ms.Add (els.ToArray ());
				bEnt.Enabled = true;
			} else if (elAct == els.Count - 1) {
				bAS.Text = "Añadir salida";
				mV.Minimum = 0;
				mV.Maximum = 1;
			} else {				
				bAS.Text = string.Format("Añadir elemento {0}",elAct);
			}
		}

		void BAN_Click (object sender, EventArgs e)
		{
			lsSm.Items.Clear ();
			ms.Clear ();
			lsSm.Items.Add ("((), )");
			AnhadirLM ();
			lsSm.Enabled = true;
			mV.Enabled = true;
			bAS.Enabled = true;
			bEnt.Enabled = false;
			lsW.Items.Add (cN.Value.ToString ());
			ws.Add ((double)cN.Value);
			bClear.Enabled = true;
		}

		void AnhadirLM(){
			els.Add (0);
			elAct = 1;
			bAS.Text = string.Format("Añadir elemento {0}",elAct);
			ActLs ();
		}

		void ActLs(){
			string pt = "(({0}), {1})";
			string sq = "";
			for (int i = 0; i != els.Count-1; i++) {
				sq += (i < elAct ? els[i].ToString () : "X") + (i+1 == els.Count-1 ? "" : ",");
			}
			lsSm.Items [lsSm.Items.Count - 1] = new ListViewItem(string.Format (pt, 
				sq, (elAct == els.Count ? els [els.Count - 1].ToString () : "X")));			
		}
	}
}