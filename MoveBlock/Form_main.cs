using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace MoveBlock {
	public partial class Form_main : Form {
		static int siz = 100, row = 5, col = 7;
		Image[,] img = new Image[col, row];
		Point[,] map = new Point[col, row];
		int[,] dist = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };//左右上下
		string dir = System.Environment.CurrentDirectory + "\\res\\";
		ArrayList pic = new ArrayList();
		Bitmap orgIMG; Graphics g;
		DateTime BeginTime;
		int tot = 0;
		Point now;

		public Form_main() {
			InitializeComponent();
		}

		private void Form_main_Load(object sender, EventArgs e) {
			ClientSize = new Size(col * siz - 1, row * siz - 1);
			Rectangle rect = Screen.GetWorkingArea(this);
			Left = (rect.Width - Width) / 2;
			Top = (rect.Height - Height) / 2;

			string[] files = Directory.GetFiles(dir, "*.jpg");
			foreach (string t in files) {
				pic.Add(t);
			}
			Game_Load();
		}

		Image ImageWhite() {
			Bitmap ret = new Bitmap(siz, siz);
			Graphics g = Graphics.FromImage(ret);
			g.Clear(Color.White);
			return ret;
		}

		Bitmap CropImage(Bitmap source, Rectangle s) {
			Bitmap bmp = new Bitmap(s.Width, s.Height);
			Graphics g = Graphics.FromImage(bmp);
			g.DrawImage(source, 0, 0, s, GraphicsUnit.Pixel);
			Pen p = new Pen(Color.White, 1);
			g.DrawLine(p, new Point(s.Height - 1, 0), new Point(s.Height - 1, s.Width - 1));
			g.DrawLine(p, new Point(0, s.Width - 1), new Point(s.Height - 1, s.Width - 1));
			return bmp;
		}

		void Game_Load() {
			BeginTime = DateTime.UtcNow;

			Random r = new Random();
			string f = (string)pic[r.Next(0, pic.Count)];

			orgIMG = new Bitmap(col * siz - 1, row * siz - 1);
			g = Graphics.FromImage(orgIMG);
			pB.Image = orgIMG;
			
			Bitmap bmp = new Bitmap(f);
			bmp.SetResolution(96, 96);
			for (int i = 0; i < col; i++) {
				for (int j = 0; j < row; j++) {
					img[i, j] = CropImage(bmp, new Rectangle(i * siz, j * siz, siz, siz));
					map[i, j] = new Point(i, j);
				}
			}
			tot = col * row;
			now = new Point(col - 1, row - 1);
			img[col - 1, row - 1] = ImageWhite();
			Game_Init();
		}

		void Game_Swap(Point a, Point b) {
			if (map[a.X, a.Y].X == a.X && map[a.X, a.Y].Y == a.Y) tot--;
			if (map[a.X, a.Y].X == b.X && map[a.X, a.Y].Y == b.Y) tot++;
			if (map[b.X, b.Y].X == b.X && map[b.X, b.Y].Y == b.Y) tot--;
			if (map[b.X, b.Y].X == a.X && map[b.X, b.Y].Y == a.Y) tot++;
			Point t = map[a.X, a.Y];
			map[a.X, a.Y] = map[b.X, b.Y];
			map[b.X, b.Y] = t;
		}

		void Game_Init() {
			Random r = new Random();
			for (int i = 1; i <= 1000; i++) {
				Point np = new Point();
				while (true) {
					int t = r.Next(0, 4);
					np.X = dist[t, 0] + now.X;
					np.Y = dist[t, 1] + now.Y;
					if (np.X < 0 || np.X >= col || np.Y < 0 || np.Y >= row) continue;
					else break;
				}
				Game_Swap(np, now);
				now = np;
			}

			for (int i = 0; i < col; i++) {
				for (int j = 0; j < row; j++) {
					Image temp = img[map[i, j].X, map[i, j].Y];
					g.DrawImage(temp, new Point(i * siz, j * siz));
				}
			}
		}

		private void Form_main_KeyDown(object sender, KeyEventArgs e) {
			int t = 0;
			switch (e.KeyCode) {
				case Keys.Up: t = 2; break;
				case Keys.Down: t = 3; break;
				case Keys.Left: t = 0; break;
				case Keys.Right: t = 1; break;
				default: return;
			}
			Point np = new Point();
			np.X = now.X + dist[t, 0];
			np.Y = now.Y + dist[t, 1];
			if (np.X < 0 || np.X >= col || np.Y < 0 || np.Y >= row) return;
			Game_Swap(now, np);
			Game_Move(now, np);
			now = np;
			if (tot == col * row) {
				Game_End();
			}
		}

		void Game_End() {
			int t = (int)(DateTime.UtcNow - BeginTime).TotalSeconds;
			MessageBox.Show("顺利通关,耗时" + t + "秒~", "<(~︶~)>");
			Game_Load();
		}

		void Game_Move(Point a,Point b) {
			g.DrawImage(img[map[a.X, a.Y].X, map[a.X, a.Y].Y], new Point(a.X * siz, a.Y * siz));
			g.DrawImage(img[map[b.X, b.Y].X, map[b.X, b.Y].Y], new Point(b.X * siz, b.Y * siz));
			pB.Image = orgIMG;
		}
	}
}
