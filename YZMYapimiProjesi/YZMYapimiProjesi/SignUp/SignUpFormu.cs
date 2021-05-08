﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YZMYapimiProjesi.Login;
using System.Data.SqlClient;

namespace YZMYapimiProjesi.SignUp
{
    public partial class SignUpFormu : Form
    {
        public SignUpFormu()
        {
            InitializeComponent();
        }

        string kullaniciTipi;


        //Build Data base connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mahmud\Desktop\YZMYapimi\YZMYapimiProjesi\YZMYapimiProjesi\Database1.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();    

        private void btnSgnUp_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" && txtSoyad.Text == "" && txtKullaniciAdi.Text == "" && txtTC.Text == "" && txtTelNo.Text == "" && txtEposta.Text == "" && txtSifre1.Text == "" && txtSifre2.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz.", "Kayıt Olunmadı" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSifre1.Text == txtSifre2.Text)
            {
                con.Open();

                string query = "INSERT INTO [KullaniciTable](kullaniciAdi,Sifre,Adi,Soyadi,Email,TCKimlik,Tel,Adres,KullaniciTipi) VALUES('" + txtKullaniciAdi.Text+ "', '" + txtSifre1.Text + "', '" + txtAd.Text+ "',  '" + txtSoyad.Text+ "', '" +txtEposta.Text+ "', '" + txtTC.Text+ "', '" +txtTelNo.Text+ "',  '" +txtAdres.Text+ "', '" + kullaniciTipi+ "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Kayıdınız Başarıyla Tamamlanmıştır!", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm frm = new LoginForm();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmiyor, Lüfen Tekrar Deneyiniz.", "Kayıt Olunmadı", MessageBoxButtons.OK , MessageBoxIcon.Error);
                txtSifre1.Text = "";
                txtSifre2.Text = "";
                txtSifre1.Focus();
            }
        }

        private void PBimageGeriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm = new LoginForm();
            frm.Show();
        }

        readonly YaziSartlari sart = new YaziSartlari();
        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            sart.AllowNumberOnly(e, txtTC, errorProvider1);
        }

        private void txtTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            sart.AllowNumberOnly(e, txtTelNo, errorProvider2);
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            sart.AllowTextOnly(e, txtAd, errorProvider3);
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            sart.AllowTextOnly(e, txtSoyad, errorProvider3);
        }
        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            sart.denaySpace(e, txtKullaniciAdi, errProvKullaniciAdi);
        }
        private void RBsatici_CheckedChanged(object sender, EventArgs e)
        {
            kullaniciTipi = "Satici";
        }

        private void RBalici_CheckedChanged(object sender, EventArgs e)
        {
            kullaniciTipi = "Alici";
        }


    }
}
