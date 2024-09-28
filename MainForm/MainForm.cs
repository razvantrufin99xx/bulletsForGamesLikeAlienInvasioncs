/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 9/28/2024
 * Time: 4:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace bullet
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			g = this.panel1.CreateGraphics();
			f = this.Font;
			h = this.panel1.Height-5;
		}
		
		public Graphics g;
		public Pen p = new Pen(Color.Red,3);
		public Pen pg = new Pen(Color.Green,1);
		public Font f;
		public Brush b = new SolidBrush(Color.Black);
		
		public Random r = new Random();
		public class bulet
		{
			public int x;
			public int y;
			public bulet(){}
			public bulet(int px, int py)
			{
				this.x = px;
				this.y = py;
			}
		}
		public List<bulet> blist = new List<bulet>();
		
		void Button1Click(object sender, EventArgs e)
		{		
			
			
			for(int k = 0 ; k< 1;k++)
			{
				blist.Add(new bulet(r.Next(3,this.panel1.Width-3),h));
			}
			
			
			
			if(this.timer1.Enabled==false){
				this.timer1.Enabled = true;
			}
				
				
		}
		
		public int h=0;
		
		public int counter = 0;
		public int nrmaximofbullets = 100;
		
		void Timer1Tick(object sender, EventArgs e)
		{
			counter++;
			if(counter%60==0 && blist.Count < nrmaximofbullets){
				
				blist.Add(new bulet(r.Next(3,this.panel1.Width-3),h));
				counter = 0;
			}
			
				g.Clear(this.panel1.BackColor);
				
				for(int i  = 0 ; i < blist.Count ; i++){
					
					blist[i].y -=1;
					g.DrawLine(p,blist[i].x,blist[i].y,blist[i].x,blist[i].y-3);
					if(blist[i].y<=3)
					{
						blist[i].y = this.panel1.Width-3;
						blist[i].x = r.Next(3,this.panel1.Width-3);
						
					}
					
					try{
							//g.DrawLine(pg,blist[i].x,blist[i].y,blist[i+1].x,blist[i+1].y);
						}
						catch{};
					
				}
		}
	}
}
