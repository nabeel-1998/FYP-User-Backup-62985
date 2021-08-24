﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using FinalProject_PU.Model;
using Newtonsoft.Json;
using Refractored.Controls;
using System;
using System.Threading.Tasks;

namespace FinalProject_PU
{

    [Activity(Label = "Manhole2",NoHistory =true)]
    public class Manhole2 : Activity
    {
        static string selected;
        ImageView createissue4_back, createissue4_next, createissue4_radio1,
                    createissue4_radio2, createissue4_radio3, iconSettngs, iconMap, iconNotifications, iconFunds, iconHome;
        RadioButton createissue4_radiobtn1, createissue4_radiobtn2, createissue4_radiobtn3;
        CircleImageView circleimageview4;
        User u;
        TextView create_issue_3_tvusername, create_issue_3_tv, tev1;
        Typeface tf;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.createissue4);


            circleimageview4 = (CircleImageView)FindViewById(Resource.Id.circleImageView24);
            create_issue_3_tvusername = (TextView)FindViewById(Resource.Id.create_issue_3_tvusername);
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            create_issue_3_tvusername.SetTypeface(tf, TypefaceStyle.Bold);

            create_issue_3_tv = (TextView)FindViewById(Resource.Id.create_issue_3_tv);
           // tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
           // create_issue_3_tv.SetTypeface(tf, TypefaceStyle.Bold);
            //runtime py profile change krna or name change krna 
            //start
            
          char[] arr = Control.UserInfoHolder.User_name.ToCharArray();
            create_issue_3_tvusername.SetText(arr, 0, arr.Length);
            byte[] arra = Convert.FromBase64String(Control.UserInfoHolder.Profile_pic);

            
            Android.Graphics.Bitmap bitmapp = BitmapFactory.DecodeByteArray(arra, 0, arra.Length);
            circleimageview4.SetImageBitmap(bitmapp);
            //end

            tev1 = (TextView)FindViewById(Resource.Id.tev1);
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            tev1.SetTypeface(tf, TypefaceStyle.Bold);


          
       
            createissue4_next = (ImageView)FindViewById(Resource.Id.create_issue4_btnnext);
            createissue4_next.Click += Createissue4_next_Click;

            createissue4_radiobtn1 = (RadioButton)FindViewById(Resource.Id.create_issue4_radiobtn1);
            createissue4_radiobtn1.Click += Createissue4_radiobtn1_Click;
            createissue4_radiobtn2 = (RadioButton)FindViewById(Resource.Id.create_issue4_radiobtn2);
            createissue4_radiobtn2.Click += Createissue4_radiobtn2_Click;
            createissue4_radiobtn3 = (RadioButton)FindViewById(Resource.Id.create_issue4_radiobtn3);
            createissue4_radiobtn3.Click += Createissue4_radiobtn3_Click;

            createissue4_radio1 = (ImageView)FindViewById(Resource.Id.crt_issue_4_radio1);
            createissue4_radio1.Click += Createissue4_radio1_Click;
            createissue4_radio2 = (ImageView)FindViewById(Resource.Id.crt_issue_4_radio2);
            createissue4_radio2.Click += Createissue4_radio2_Click;
            createissue4_radio3 = (ImageView)FindViewById(Resource.Id.crt_issue_4_radio3);
            createissue4_radio3.Click += Createissue4_radio3_Click;
        }
        private void Createissue4_radiobtn1_Click(object sender, EventArgs e)
        {
            createissue4_radio1.PerformClick();
        }

        private void Createissue4_radiobtn2_Click(object sender, EventArgs e)
        {
            createissue4_radio2.PerformClick();
        }
        long lastPress;
        public override void OnBackPressed()
        {
            // source https://stackoverflow.com/a/27124904/3814729
            long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;

            // source https://stackoverflow.com/a/14006485/3814729
            if (currentTime - lastPress > 5000)
            {
                Toast.MakeText(this, "Press back again to exit", ToastLength.Long).Show();
                lastPress = currentTime;
            }
            else
            {

                FinishAffinity();

            }
        }
        private void Createissue4_radiobtn3_Click(object sender, EventArgs e)
        {
            createissue4_radio1.PerformClick();
        }
        private void Createissue4_radio3_Click(object sender, EventArgs e)
        {
            selected = "fourlane";
            createissue4_radiobtn3.Checked = true;
            createissue4_radiobtn2.Checked = false;
            createissue4_radiobtn1.Checked = false;
        }

        private void Createissue4_radio2_Click(object sender, EventArgs e)
        {
            selected="threelane";
            createissue4_radiobtn2.Checked = true;
            createissue4_radiobtn3.Checked = false;
            createissue4_radiobtn1.Checked = false;
        }

        private void Createissue4_radio1_Click(object sender, EventArgs e)
        {
            selected = "twolane";
            createissue4_radiobtn1.Checked = true;
            createissue4_radiobtn2.Checked = false;
            createissue4_radiobtn3.Checked = false;
        }

        private async void Createissue4_next_Click(object sender, EventArgs e)
        {
            if (selected != "")
            {


                await Task.Run(() =>
                {
                    var man = JsonConvert.DeserializeObject<Model.Manhole>(Intent.GetStringExtra("objtopass"));
                    man.roadSize = selected;
                    FinalProject_PU.Control.DataOper.PutData<Manhole3>(this, man);
                });
            }
            else
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                {
                    Toast.MakeText(this, "Please select any one from them", ToastLength.Long).Show();
                });
            }
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