﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using YZMYapimiProjesi.SignUp;
using YZMYapimiProjesi.Alici;
using YZMYapimiProjesi.Admin;
using YZMYapimiProjesi.Satici;
using YZMYapimiProjesi.DB;
using YZMYapimiProjesi.Muhabe_Kullanicisi;

namespace YZMYapimiProjesi.Login
{
    public partial class LoginForm : Form
    {
        private readonly DbEntity _db;
 
        public LoginForm()
        {
            InitializeComponent();
            _db = new DbEntity();
        }
        public LoginForm(string name)
        {
            InitializeComponent();
            _db = new DbEntity();
            textBox1.Text = name;
        }
        
       
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpFormu sgnFrm = new SignUpFormu();
            sgnFrm.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            try
            {

                var kullanici = textBox1.Text.Trim();
                var sifre = Login.Text;
                var user = _db.KullaniciTable.FirstOrDefault(q => q.KullaniciAdi == kullanici && q.Sifre == sifre);
                if (user == null)
                {
                    MessageBox.Show("Hatali Sifre Veya Kullanici Adi Girdiniz ...");
                }
                else
                {
                    var role = user.KullaniciRole.FirstOrDefault();
                    var roleNm = role.Role.KullaniciTipi;
                    var userWallet = user.WalletBalance;
                    if (roleNm == "Admin")
                    {
                        this.Hide();
                        AdminAraYuzu admin = new AdminAraYuzu();
                        admin.Show();
                    }
                    else if (roleNm == "Satici")
                    {
                        this.Hide();
                        saticiGiris saticiG = new saticiGiris(user.Id, user.Ad, Convert.ToInt32(user.WalletBalance));
                        saticiG.Show();
                        //SaticiForm satici = new SaticiForm(user.Id, user.Ad, Convert.ToInt32(user.WalletBalance));
                        //satici.Show();
                    }
                    else if (roleNm == "Alici")
                    {

                        AliciForm alici = new AliciForm(this, user.Ad, Convert.ToInt32(userWallet), user.Id);

                        alici.Show();

                        Hide();
                    }
                    else if (roleNm == "Muhasebeci")
                    {

                        muhasebe_kullanicisi_form muhasebeci = new muhasebe_kullanicisi_form();

                        muhasebeci.Show();

                        Hide();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
