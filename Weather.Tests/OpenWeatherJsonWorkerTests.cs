using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.OpenWeatherAPI;

namespace Tests
{
    public class OpenWeatherJsonWorkerTests
    {
        private OpenWeatherJsonWorker openWeatherJsonWorker;
        private string testJson = "{'coord':{'lon':-115.15,'lat':36.17},'weather':[{'id':800,'main':'Clear','description':'Klarer Himmel','icon':'01d'}],'base':'stations','main':{'temp':310.79,'pressure':1011,'humidity':6,'temp_min':307.15,'temp_max':313.15},'visibility':16093,'wind':{'speed':5.41,'deg':154.264},'clouds':{'all':1},'dt':1564419939,'sys':{'type':1,'id':4763,'message':0.0107,'country':'US','sunrise':1564404301,'sunset':1564454934},'timezone':-25200,'id':5506956,'name':'Las Vegas','cod':200}";

        [SetUp]
        public void Setup()
        {
            openWeatherJsonWorker = new OpenWeatherJsonWorker();
        }

        [Test]
        public void GetRequestUrlByCityName_GiveValidCity_GetExpectedURL()
        {
            string actualValue = openWeatherJsonWorker.GetRequestUrlByCityName("Las Vegas");
            Assert.IsTrue(actualValue.StartsWith("https://api.openweathermap.org/data/2.5/weather?q=Las+Vegas"));
        }

        [Test]
        public void GetDynamicObject_GiveValidContent_GetUsableObject()
        {
            dynamic dynamicTestFoo = openWeatherJsonWorker.GetDynamicObject(testJson);
            string foo = dynamicTestFoo.name;
            Assert.AreEqual("Las Vegas", foo);
        }
    }
}