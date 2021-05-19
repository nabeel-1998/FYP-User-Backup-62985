﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FinalProject_PU.Model;
using Newtonsoft.Json;
using Refractored.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject_PU.Control;

namespace FinalProject_PU
{
    [Activity(Label = "createissue3")]
    public class createissue3 : Activity
    {
        ImageView radio1, radio2, radio3, iconSettngs, iconMap, iconNotifications, iconFunds, iconHome, back_imga1, next_imga2;
        RadioButton radiobtn1, radiobtn2, radiobtn3;
        TextView tvusername, infoprob;
        Typeface tf;
        CircleImageView circleimageview3;
        static string selected;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.createisue3);
            circleimageview3 = (CircleImageView)FindViewById(Resource.Id.circleImageView3);
            iconSettngs = (ImageView)FindViewById(Resource.Id.iconSettings);
            iconSettngs.Click += IconSettngs_Click;
            iconMap = (ImageView)FindViewById(Resource.Id.iconMap);
            iconMap.Click += IconMap_Click;
            iconNotifications = (ImageView)FindViewById(Resource.Id.iconNotifications);
            iconNotifications.Click += IconNotifications_Click;
            iconFunds = (ImageView)FindViewById(Resource.Id.iconFunds);
            iconFunds.Click += IconFunds_Click;
            iconHome = (ImageView)FindViewById(Resource.Id.iconHome);
            iconHome.Click += IconHome_Click;
           
            next_imga2 = (ImageView)FindViewById(Resource.Id.create_issue4_btnnext);
            next_imga2.Click += Next_imga2_Click;

            radio1 = (ImageView)FindViewById(Resource.Id.crt_issue_3_radio1);
            radio1.Click += Radio1_Click;
            radio2 = (ImageView)FindViewById(Resource.Id.crt_issue_3_radio2);
            radio2.Click += Radio2_Click;
            radio3 = (ImageView)FindViewById(Resource.Id.crt_issue_3_radio3);
            radio3.Click += Radio3_Click;

            tvusername = (TextView)FindViewById(Resource.Id.create_issue_3_tvusername);
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            tvusername.SetTypeface(tf, TypefaceStyle.Bold);

            infoprob = (TextView)FindViewById(Resource.Id.create_issue_3_tv);
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            infoprob.SetTypeface(tf, TypefaceStyle.Bold);

            radiobtn1 = (RadioButton)FindViewById(Resource.Id.create_issue3_radiobtn1);
            radiobtn1.Click += Radiobtn1_Click;
            radiobtn2 = (RadioButton)FindViewById(Resource.Id.create_issue3_radiobtn2);
            radiobtn2.Click += Radiobtn2_Click;
            radiobtn3 = (RadioButton)FindViewById(Resource.Id.create_issue3_radiobtn3);
            radiobtn3.Click += Radiobtn3_Click;
              //runtime py profile change krna or name change krna 
            //start
          
            char[] arr = Control.UserInfoHolder.User_name.ToCharArray();
            byte[] arra = Convert.FromBase64String(Control.UserInfoHolder.Profile_pic);
            Android.Graphics.Bitmap bitmapp = BitmapFactory.DecodeByteArray(arra, 0, arra.Length);
            circleimageview3.SetImageBitmap(bitmapp);
            tvusername.SetText(arr, 0, arr.Length);
            //end //runtime py profile change krna or name change krna 




        }

        private void Radiobtn3_Click(object sender, EventArgs e)
        {
            radio3.PerformClick();
        }

        private void Radiobtn2_Click(object sender, EventArgs e)
        {
            radio2.PerformClick();
        }

        private void Radiobtn1_Click(object sender, EventArgs e)
        {
            radio1.PerformClick();
        }

        private void Radio3_Click(object sender, EventArgs e)
        {

            selected = "partially covered in water";
            radiobtn3.Checked = true;
            radiobtn2.Checked = false;
            radiobtn1.Checked = false;

        }

        private void Radio2_Click(object sender, EventArgs e)
        {
            selected = "fully covered in water";
            radiobtn2.Checked = true;
            radiobtn3.Checked = false;
            radiobtn1.Checked = false;
        }

        private void Radio1_Click(object sender, EventArgs e)
        {
            selected = "not covered in water";
            radiobtn1.Checked = true;
            radiobtn2.Checked = false;
            radiobtn3.Checked = false;
        }

        private void Next_imga2_Click(object sender, EventArgs e)
        {
            string a = JsonConvert.DeserializeObject<string>(Intent.GetStringExtra("objtopass"));
            Pothole p = new Pothole();
            p.IssueImage = a;
            p.waterLevel = selected;
            Control.DataOper.PutData<createissue4>(this, p);

        }

       

        private void IconHome_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(HomeActivity));
            this.StartActivity(i);
        }

        private void IconFunds_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(FundsActivity));
            this.StartActivity(i);
        }

        private void IconNotifications_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(NotificationsActivity));
            this.StartActivity(i);
        }

        private void IconMap_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(MapActivity));
            this.StartActivity(i);
        }

        private void IconSettngs_Click(object sender, EventArgs e)
        {
            var i = new Intent(this, typeof(SettingsActivity));
            this.StartActivity(i);
        }

    }
}