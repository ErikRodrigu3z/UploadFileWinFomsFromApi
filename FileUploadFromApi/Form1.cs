using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUploadFromApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "";

                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK)
                {
                    file = openFileDialog1.FileName;
                    var client = new RestClient("https://localhost:44360/api/ImageUpload");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddFile("files", file);
                    IRestResponse response = client.Execute(request);
                    //Console.WriteLine(response.Content);
                    MessageBox.Show(response.Content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            


        }
    }
}
