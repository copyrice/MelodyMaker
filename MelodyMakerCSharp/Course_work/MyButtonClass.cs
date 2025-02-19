using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_work
{
    class MyButtonClass: Button
    {

        public void CreateMyButton(Button btn, int x, int y, int w, int h, EventHandler evh, string text, Form f, int mybtn_counter, ContextMenuStrip cms)
        {
            FontFamily fam = new FontFamily("Microsoft Sans Serif");
            btn = new Button
            {
                Text = text,
                Size = new Size(w, h),
                Location = new Point(x, y),
                Font = new Font(fam, 15, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Name = "mybutton" + $"{mybtn_counter}",
                ContextMenuStrip = cms,
                Anchor = AnchorStyles.Left,
            };
            btn.Click += evh;
            f.Controls.Add(btn);
        }


    }
}
