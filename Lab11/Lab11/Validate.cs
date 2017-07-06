using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab11
{
    public class Validate : Fragment
    {
        public SALLab11.ResultInfo Resultado { get; set; }

        public override string ToString()
        {
            return $"{Resultado.Fullname} \n {Resultado.Status} \n {Resultado.Token} i";
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

    }

    



}