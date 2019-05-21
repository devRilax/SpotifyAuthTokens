using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AppToken.Services.models;
using Newtonsoft.Json;


namespace TokenApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExecuteRequest();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        static void ExecuteRequest()
        {

            //log
        }
    }
}
