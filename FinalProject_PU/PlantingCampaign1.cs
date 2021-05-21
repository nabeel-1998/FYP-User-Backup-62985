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

namespace FinalProject_PU
{
    [Activity(Label = "PlantingCampaign1")]
    public class PlantingCampaign1 : Activity
    {
        
        TextView tvusername, tvinfoproblem, tev1;
        ImageView addLocation;
        CircleImageView circleImageViewplanting;
        Typeface tf;
        User u;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PlantingCampignIssue1);


            addLocation = FindViewById<ImageView>(Resource.Id.Planting_AddLocation);
            addLocation.Click += AddLocation_Click;

            tvusername = (TextView)FindViewById(Resource.Id.tvusername);
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            tvusername.SetTypeface(tf, TypefaceStyle.Bold);

            //runtime py profile change krna or name change krna 
            //start
            circleImageViewplanting = (CircleImageView)FindViewById(Resource.Id.circleImageView2);
            char[] arr = Control.UserInfoHolder.User_name.ToCharArray();
            tvusername.SetText(arr, 0, arr.Length);
            byte[] arra = Convert.FromBase64String(Control.UserInfoHolder.Profile_pic);

           
            Android.Graphics.Bitmap bitmapp = BitmapFactory.DecodeByteArray(arra, 0, arra.Length);
            circleImageViewplanting.SetImageBitmap(bitmapp);
            //end

            tev1 = (TextView)FindViewById(Resource.Id.tev1);
            Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            tev1.SetTypeface(tf, TypefaceStyle.Bold);

            tvinfoproblem = (TextView)FindViewById(Resource.Id.tvinfoproblem);
            tf = Typeface.CreateFromAsset(Assets, "Quicksand-Bold.otf");
            tvinfoproblem.SetTypeface(tf, TypefaceStyle.Bold);

        }

        private void AddLocation_Click(object sender, EventArgs e)
        {
            Planting p = new Planting();
            p.IssueImage = JsonConvert.DeserializeObject<string>(Intent.GetStringExtra("objtopass"));
            Control.DataOper.PutData<Issuelocationpickup_PlantingCompaign>(this, p);
            
        }
    }
}