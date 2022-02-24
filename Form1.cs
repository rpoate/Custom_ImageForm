using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_ImageForm
{
    public partial class Form1 : Form
    {
        ToolStripItem itemImageProps;

        public Form1()
        {
            InitializeComponent();

            htmlEditControl1.DocumentHTML = "<p>test</p><img src='https://zoople.tech/img/logo.png' /><p>test</p>";
            htmlEditControl1.ContextMenuWYSIWYG.Items.RemoveByKey("ImagePropetiesToolStripMenuItem");

            itemImageProps = htmlEditControl1.ContextMenuWYSIWYG.Items.Add("Image Properties");
            itemImageProps.Click += ImagePropertiesContext_Click;

            htmlEditControl1.ContextMenuWYSIWYG.Opening += ContextMenuWYSIWYG_Opening;
        }

        private void ContextMenuWYSIWYG_Opening(object sender, CancelEventArgs e)
        {
            itemImageProps.Visible = htmlEditControl1.CurrentWindowsFormsElement.TagName == "IMG";
        }

        private void ImagePropertiesContext_Click(object sender, EventArgs e)
        {
            DoImage(htmlEditControl1.CurrentWindowsFormsElement);
        }

        private void htmlEditControl1_CommandsToolbarButtonClicked(object sender, Zoople.CommandsToolbarButtonClickedEventArgs e)
        {
            if (e.ButtonIdentifier == "InsertImageToolStripButton")
            {
                e.Cancelled = true;
                DoImage(htmlEditControl1.CurrentWindowsFormsElement);
            }
        }

        private void DoImage(HtmlElement HTMLImage)
        {

            frmImage oFrm = new frmImage();

            if (htmlEditControl1.CurrentWindowsFormsElement.TagName == "IMG")
            {
                oFrm.textBox1.Text = HTMLImage.GetAttribute("src");
            }

            oFrm.ShowDialog(this);

            if (!oFrm.Cancelled)
            {
                if (htmlEditControl1.CurrentWindowsFormsElement.TagName == "IMG")
                {
                    HTMLImage.SetAttribute("src", oFrm.textBox1.Text);
                }
                else
                {
                    HTMLImage = htmlEditControl1.InsertHTMLElement("img");
                    HTMLImage.SetAttribute("src", oFrm.textBox1.Text);
                }
            }
        }

        private void htmlEditControl1_CancellableUserInteraction(object sender, Zoople.CancellableUserInteractionEventsArgs e)
        {

        }
    }
}
