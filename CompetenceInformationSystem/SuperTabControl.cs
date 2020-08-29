using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CompetenceInformationSystem
{
    public class SuperTabControl : TabControl
    {
        public SuperTabControl()
        {
            GetCMS();
        }

        ContextMenuStrip _CMS;
        Point _lastClickPos;

        private void GetCMS()
        {
            _CMS = new ContextMenuStrip();
            _CMS.Items.Add("Закрыть", null, new EventHandler(Item_Click));
            return;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle r = this.GetTabRect(i);
                if (r.Contains(PointToClient(_lastClickPos)))
                {
                    this.TabPages.Remove(this.TabPages[i]);
                    return;
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _lastClickPos = Cursor.Position;
                _CMS.Show(Cursor.Position);
            }
        }
    }
}
