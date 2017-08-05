﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Otaku_Time;

namespace OtakuTimeTests
{
    [TestClass]
    public class OtakuTimeMainTests
    {
        [TestMethod]
        public void GetPhantomObjectTest()
        {
            var PhantomObject = Statics.PhantomObject();
            Assert.AreNotEqual(null, PhantomObject);
        }

        [TestMethod]
        public void ConnectToMasterTest()
        {
            var PhantomObject = Statics.PhantomObject();
            PhantomObject.Navigate().GoToUrl($"http://{Statics.MasterURL}/M");
            System.Threading.Thread.Sleep(6000); //bypass cloudflare
            string title = PhantomObject.Title;
            Console.WriteLine(title);
            Console.WriteLine(PhantomObject.Url);
            Assert.IsTrue(title.ToLower().Contains("watch"));
        }
    }
}
