﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject_PU
{
    [Activity(Label = "MyAdsFragmentSettings")]
    public class MyAdsFragmentSettings : Activity
    {
        ImageView back, uploadimg, submit;
        //CircleImageView userimage;
        TextView Username;
        EditText edturl, budget;
        private string base64image;
        private bool IsImageUploaded = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyAds);
            back = (ImageView)FindViewById(Resource.Id.imgbackgo);
            back.Click += Back_Click;
            //userimage = (CircleImageView)FindViewById(Resource.Id.usericon);
            Username = (TextView)FindViewById(Resource.Id.username);
            uploadimg = (ImageView)FindViewById(Resource.Id.imguploadimg);
            uploadimg.Click += Uploadimg_Click;
            edturl = (EditText)FindViewById(Resource.Id.edtUrl);
            submit = (ImageView)FindViewById(Resource.Id.imgsubmitt);
            submit.Click += Submit_Click;
            budget = FindViewById<EditText>(Resource.Id.edtBudget);



            // Create your fragment here
        }


        private void Submit_Click(object sender, EventArgs e)
        {
            if(Control.InputValidation.validateUri(edturl.Text))
            {
                if(IsImageUploaded)
                {
                    int budgetAmount;
                   if(int.TryParse(budget.Text,out budgetAmount))
                    {
                        var intent = new Intent(this, typeof(AdTitleandTextActivity));
                        intent.PutExtra("baseimage", JsonConvert.SerializeObject(base64image));
                        intent.PutExtra("budget", JsonConvert.SerializeObject(budgetAmount));
                        intent.PutExtra("link", JsonConvert.SerializeObject(edturl.Text));
                        StartActivity(intent);
                    }
                   else
                    {
                        Toast.MakeText(this, "Please enter budget amount", ToastLength.Long).Show();
                    }
                    
                }
                else
                {
                    Toast.MakeText(this, "Please upload an image for your ad", ToastLength.Long).Show();
                }

            }
            else
            {
                Toast.MakeText(this, "Please enter correct website address", ToastLength.Long).Show();
            }
        }

        private void Uploadimg_Click(object sender, EventArgs e)
        {
            try
            { 
                UploadPhoto();  
            }
            catch(NullReferenceException)
            {
                Toast.MakeText(this, "Please select any photo to upload", ToastLength.Long).Show();
            }
            catch(Exception)
            {
                Toast.MakeText(this, "Image couldn't be selected at this time", ToastLength.Long).Show();
            }
        }

        public async void UploadPhoto()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    Toast.MakeText(this, "upload not supported on this device", ToastLength.Short).Show();

                }

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                    CompressionQuality = 90

                });

                //convert file to byte array , to bitmap
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                base64image = Convert.ToBase64String(imageArray);
                IsImageUploaded = true;


            }
            catch (Exception ex)
            { Toast.MakeText(this, "Please select any image to represent the issue",ToastLength.Long).Show(); }




        }
        private void Back_Click(object sender, EventArgs e)
        {

        }
    }
}